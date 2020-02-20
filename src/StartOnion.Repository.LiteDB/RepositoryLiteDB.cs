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
        public readonly ContextRepositoryLiteDB ContextLiteDB;

        protected RepositoryLiteDB(ContextRepositoryLiteDB context)
        {
            ContextLiteDB = context;
        }

        public void Add(TEntity entidade)
            => ContextLiteDB.Session.GetCollection<TEntity>().Insert(entidade);

        public void Add(ICollection<TEntity> entidades)
            => ContextLiteDB.Session.GetCollection<TEntity>().InsertBulk(entidades);

        public TEntity GetById(Guid id)
            => ContextLiteDB.Session.GetCollection<TEntity>().FindById(new BsonValue(id));

        public void Remove(TEntity entidade)
            => ContextLiteDB.Session.GetCollection<TEntity>().Delete(new BsonValue(entidade.Id));

        public void Remove(ICollection<TEntity> entidades)
        {
            foreach (var entidade in entidades)
                Remove(entidade);
        }
    }
}
