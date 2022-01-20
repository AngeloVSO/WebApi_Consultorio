using CA.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Manager.Interfaces
{
    public interface IClientRepository
    {
        Task DeleteClienteAsync(int id);
        Task<Client?> GetClienteByIdAsync(int id);
        Task<IEnumerable<Client>> GetClientesAsync();
        Task<Client> InsertClienteAsync(Client cliente);
        Task<Client> UpdateClienteAsync(Client cliente);
    }
}
