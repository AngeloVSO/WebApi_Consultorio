using CA.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data.Context
{
    public class CAContext : DbContext
    {
        public DbSet<Client> Clientes { get; set; }

        public CAContext(DbContextOptions options) : base(options)
        {

        }
    }
}
