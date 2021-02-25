using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TDSA.DesafioCrud.Domain.Interfaces;
using TDSA.DesafioCrud.Domain.Models;

namespace TDSA.DesafioCrud.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public IEnumerable<Cliente> CarregarAtivos()
        {
            return _DbSet.Where(c => c.Ativo == true).ToList();
        }
    }
}
