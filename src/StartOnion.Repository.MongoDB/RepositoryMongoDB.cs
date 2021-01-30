using MongoDB.Driver;
using StartOnion.Domain;
using StartOnion.Domain.Interfaces;
using StartOnion.Repository.MongoDB.Contexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartOnion.Repository.MongoDB
{
    public abstract class RepositoryMongoDB<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public readonly ContextRepositoryMongoDB ContextMongoDB;
        public readonly IMongoCollection<TEntity> DbSet;
        public readonly FilterDefinitionBuilder<TEntity> Filter;

        protected RepositoryMongoDB(ContextRepositoryMongoDB context, string collectionName)
        {
            ContextMongoDB = context;
            DbSet = ContextMongoDB.Database.GetCollection<TEntity>(collectionName);
            Filter = Builders<TEntity>.Filter;
        }

        public void Add(TEntity entity) => ContextMongoDB.AddCommand(() => DbSet.InsertOneAsync(entity));

        public void Add(ICollection<TEntity> entities) => ContextMongoDB.AddCommand(async () => await DbSet.InsertManyAsync(entities));

        public IEnumerable<TEntity> GetAll() => DbSet.Find(DefaultFilters<TEntity>.Empty()).ToList();

        public TEntity GetById(Guid id) => DbSet.Find(DefaultFilters<TEntity>.EqualsById(id)).SingleOrDefault();

        public TEntity GetById(string id) => DbSet.Find(DefaultFilters<TEntity>.EqualsById(id)).SingleOrDefault();

        public void Remove(TEntity entity) =>
            ContextMongoDB.AddCommand(() => DbSet.DeleteOneAsync(DefaultFilters<TEntity>.EqualsById(entity)));

        public void Remove(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
                Remove(entity);
        }

        public void Update(TEntity entity) => 
            ContextMongoDB.AddCommand(() => DbSet.ReplaceOneAsync(DefaultFilters<TEntity>.EqualsById(entity.Id), entity));

        public void Update(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
                Update(entity);
        }
    }
}
