using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TDSA.DesafioCrud.Domain.Interfaces;
using TDSA.DesafioCrud.Domain.Models;
using TDSA.DesafioCrud.Infra.Data.Context;

namespace TDSA.DesafioCrud.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected DesafioCrudContext _Db;
        protected DbSet<TEntity> _DbSet;

        public Repository()
        {
            _Db = new DesafioCrudContext();
            _DbSet = _Db.Set<TEntity>();
        }

        public void Adicionar(TEntity obj)
        {
            _DbSet.Add(obj);
            SaveChanges();
        }

        public void Atualizar(TEntity obj)
        {
            var entry = _Db.Entry(obj);
            _DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();
        }

        public IEnumerable<TEntity> CarregarTodos()
        {
            return _DbSet.ToList();
        }

        public TEntity CarregarUm(int id)
        {
            return _DbSet.FirstOrDefault(c => c.Id == id);
        }
                
        public void Remover(int id)
        {
            var entity = new TEntity { Id = id };
            var entry = _Db.Entry(entity);
            entry.State = EntityState.Deleted;
            _DbSet.Remove(entity);
            SaveChanges();
        }

        public int SaveChanges()
        {
            return _Db.SaveChanges();
        }

        public void Dispose()
        {
            _Db.Dispose();
        }
    }
}
