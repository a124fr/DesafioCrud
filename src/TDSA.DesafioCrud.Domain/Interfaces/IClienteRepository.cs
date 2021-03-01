using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSA.DesafioCrud.Domain.Models;

namespace TDSA.DesafioCrud.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IEnumerable<Cliente> CarregarAtivos();
        void GerenciarSituacao(int id, bool op);
    }
}
