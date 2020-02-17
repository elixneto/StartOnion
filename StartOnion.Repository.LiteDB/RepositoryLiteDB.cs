using LiteDB;
using StartOnion.Domain;
using StartOnion.Domain.Interfaces;
using StartOnion.Repository.LiteDB.Contexts;
using System;
using System.Collections.Generic;

namespace StartOnion.Repository.LiteDB
{
    public abstract class RepositoryLiteDB<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public readonly ContextRepositoryLiteDB _contexto;

        protected RepositoryLiteDB(ContextRepositoryLiteDB contexto)
        {
            _contexto = contexto;
        }

        public void Add(TEntity entidade)
            => _contexto.Sessao.GetCollection<TEntity>().Insert(entidade);

        public void Add(ICollection<TEntity> entidades)
            => _contexto.Sessao.GetCollection<TEntity>().InsertBulk(entidades);

        public TEntity GetById(Guid id)
            => _contexto.Sessao.GetCollection<TEntity>().FindById(new BsonValue(id));

        public void Remove(TEntity entidade)
            => _contexto.Sessao.GetCollection<TEntity>().Delete(new BsonValue(entidade.Id));

        public void Remove(ICollection<TEntity> entidades)
        {
            foreach (var entidade in entidades)
                Remove(entidade);
        }
    }
}
