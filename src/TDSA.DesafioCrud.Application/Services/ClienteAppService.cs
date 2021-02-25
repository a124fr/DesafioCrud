using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSA.DesafioCrud.Application.Interfaces;
using TDSA.DesafioCrud.Application.ViewModels;
using TDSA.DesafioCrud.Domain.Interfaces;
using TDSA.DesafioCrud.Domain.Models;
using TDSA.DesafioCrud.Infra.Data.Repository;

namespace TDSA.DesafioCrud.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private IClienteRepository _clienteRepository;

        public ClienteAppService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public void Adicionar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            _clienteRepository.Adicionar(cliente);
        }

        public void Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            _clienteRepository.Atualizar(cliente);
        }

        public IEnumerable<ClienteViewModel> CarregarAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.CarregarAtivos());
        }

        public IEnumerable<ClienteViewModel> CarregarTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.CarregarTodos());
        }

        public ClienteViewModel CarregarUm(int id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.CarregarUm(id));
        }
        
        public void Remover(int id)
        {
            _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
