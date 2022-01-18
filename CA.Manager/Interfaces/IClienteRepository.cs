using CA.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Manager.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetClienteByIdAsync(int id);
        Task<IEnumerable<Cliente>> GetClientesAsync();
    }
}
