using CA.Core.Domain;
using CA.Data.Context;
using CA.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CAContext _context;

        public ClienteRepository(CAContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente?> GetClienteByIdAsync(int id)
        {
            //return await _context.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync();  -------  outra opção
            //return await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);   -------  outra opção2
            //return await _context.Clientes.SingleOrDefaultAsync(c => c.Id == id);  -------  outra opção3 se existir mais de 1, vai retornar um erro

            return await _context.Clientes.FindAsync(id); // antes de pegar do banco, verifica se ja tem em memoria tendo ganho de performance
        }

        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var clientExists = await _context.Clientes.FindAsync(cliente.Id);
            if (clientExists == null) return null;
            
            _context.Entry(clientExists).CurrentValues.SetValues(cliente);
            await _context.SaveChangesAsync();
            
            return clientExists;
        }

        public async Task DeleteClienteAsync(int id)
        {
            var clientExists = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clientExists);
            await _context.SaveChangesAsync();
        }
    }
}
