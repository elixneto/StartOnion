using StartOnion.Domain;
using StartOnion.Domain.Interfaces;
using StartOnion.Repository.SQLServer.Contexts;
using System.Collections.Generic;

namespace StartOnion.Repository.SQLServer
{
    public abstract class RepositorySQLServer<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public readonly ContextRepositorySQLServer ContextSQLServer;

        protected RepositorySQLServer(ContextRepositorySQLServer contextSQLServer)
        {
            ContextSQLServer = contextSQLServer;
        }

        public virtual void Add(TEntity entity)
            => ContextRavenDB.Session.Store(entity);

        public virtual void Add(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
                this.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
            => ContextRavenDB.Session.Query<TEntity>().ToList();

        public virtual TEntity GetById(Guid id)
            => ContextRavenDB.Session.Load<TEntity>(id.ToString());

        public virtual void Remove(TEntity entity)
            => ContextRavenDB.Session.Delete(entity);

        public virtual void Remove(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
                this.Remove(entity);
        }
    }
}
