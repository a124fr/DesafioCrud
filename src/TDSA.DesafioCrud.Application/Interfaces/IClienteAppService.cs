using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSA.DesafioCrud.Application.ViewModels;

namespace TDSA.DesafioCrud.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        IEnumerable<ClienteViewModel> CarregarTodos();
        IEnumerable<ClienteViewModel> CarregarAtivos();
        ClienteViewModel CarregarUm(int id);        
        void Adicionar(ClienteViewModel clienteViewModel);
        void Atualizar(ClienteViewModel clienteViewModel);
        void Remover(int id);
    }
}
