using MongoDB.Driver;
using StartOnion.Domain;
using System;

namespace StartOnion.Repository.MongoDB
{
    public static class DefaultFilters<TEntity> where TEntity : Entity
    {
        public static FilterDefinition<TEntity> Empty()
            => Builders<TEntity>.Filter.Empty;

        public static FilterDefinition<TEntity> EqualsById(TEntity entity)
            => Builders<TEntity>.Filter.Eq(e => e.Id, entity.Id.ToString());

        public static FilterDefinition<TEntity> EqualsById(string id)
            => Builders<TEntity>.Filter.Eq(e => e.Id, id);

        public static FilterDefinition<TEntity> EqualsById(Guid id)
            => EqualsById(id.ToString());
    }
}
