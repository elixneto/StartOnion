using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartOnion.Domain.Interfaces
{
    public interface IRepositoryAsync<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetById(Guid id);
        Task Add(TEntity entity);
        Task Add(ICollection<TEntity> entities);
        void Remove(TEntity entity);
        void Remove(ICollection<TEntity> entities);
    }
}
