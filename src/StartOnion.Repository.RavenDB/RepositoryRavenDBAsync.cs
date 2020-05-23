using Raven.Client.Documents;
using StartOnion.Domain;
using StartOnion.Domain.Interfaces;
using StartOnion.Repository.RavenDB.Contexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartOnion.Repository.RavenDB
{
    public abstract class RepositoryRavenDBAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : Entity
    {
        public readonly ContextRepositoryRavenDBAsync ContextRavenDB;

        protected RepositoryRavenDBAsync(ContextRepositoryRavenDBAsync context)
        {
            ContextRavenDB = context;
        }

        public virtual async Task Add(TEntity entity)
            => await ContextRavenDB.Session.StoreAsync(entity);

        public virtual async Task Add(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
                await this.Add(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
            => await ContextRavenDB.Session.Query<TEntity>().ToListAsync();

        public virtual async Task<TEntity> GetById(Guid id)
            => await ContextRavenDB.Session.LoadAsync<TEntity>(id.ToString());

        public virtual void Remove(TEntity entity)
            => ContextRavenDB.Session.Delete(entity);

        public virtual void Remove(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
                this.Remove(entity);
        }
    }
}
