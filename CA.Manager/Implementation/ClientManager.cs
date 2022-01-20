using CA.Core.Domain;
using CA.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Manager.Implementation
{
    public class ClientManager : IClientManager
    {
        private readonly IClientRepository _clienteRepository;

        public ClientManager(IClientRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Client>> GetClientesAsync()
        {
            return await _clienteRepository.GetClientesAsync();
        }

        public async Task<Client?> GetClienteAsync(int id)
        {
            return await _clienteRepository.GetClienteByIdAsync(id);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _clienteRepository.DeleteClienteAsync(id);
        }

        public async Task<Client> InsertClienteAsync(Client cliente)
        {
            return await _clienteRepository.InsertClienteAsync(cliente);
        }

        public async Task<Client> UpdateClienteAsync(Client cliente)
        {
            return await _clienteRepository.UpdateClienteAsync(cliente);
        }
    }
}
