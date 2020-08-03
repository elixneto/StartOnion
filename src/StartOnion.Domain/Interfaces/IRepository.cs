using System;
using System.Collections.Generic;

namespace StartOnion.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
        TEntity GetById(string id);
        void Add(TEntity entity);
        void Add(ICollection<TEntity> entities);
        void Remove(TEntity entity);
        void Remove(ICollection<TEntity> entities);
    }
}
