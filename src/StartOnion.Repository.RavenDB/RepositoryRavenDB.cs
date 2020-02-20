using StartOnion.Domain;
using StartOnion.Domain.Interfaces;
using StartOnion.Repository.RavenDB.Contexts;
using System;
using System.Collections.Generic;

namespace StartOnion.Repository.RavenDB
{
    public abstract class RepositoryRavenDB<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public readonly ContextRepositoryRavenDB ContextRavenDB;

        protected RepositoryRavenDB(ContextRepositoryRavenDB context)
        {
            ContextRavenDB = context;
        }

        public virtual void Add(TEntity entity) => ContextRavenDB.Session.Store(entity);

        public virtual void Add(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
                this.Add(entity);
        }

        public virtual TEntity GetById(Guid id) => ContextRavenDB.Session.Load<TEntity>(id.ToString());

        public virtual void Remove(TEntity entity) => ContextRavenDB.Session.Delete(entity);

        public virtual void Remove(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
                this.Remove(entity);
        }
    }
}
