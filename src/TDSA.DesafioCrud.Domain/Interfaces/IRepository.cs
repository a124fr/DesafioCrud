using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TDSA.DesafioCrud.Domain.Models;

namespace TDSA.DesafioCrud.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity, new()
    {
        IEnumerable<TEntity> CarregarTodos();

        TEntity CarregarUm(int id);

        void Adicionar(TEntity obj);

        void Atualizar(TEntity obj);

        void Remover(int id);
        
        int SaveChanges();
    }
}
