using MongoDB.Driver;
using StartOnion.Domain;
using StartOnion.Domain.Interfaces;
using StartOnion.Repository.MongoDB.Contexts;
using System;
using System.Collections.Generic;

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

        public void Add(TEntity entity) => DbSet.InsertOneAsync(ContextMongoDB.Session, entity);

        public void Add(ICollection<TEntity> entities) => DbSet.InsertManyAsync(ContextMongoDB.Session, entities);

        public IEnumerable<TEntity> GetAll() => DbSet.Find(ContextMongoDB.Session, DefaultFilters<TEntity>.Empty()).ToList();

        public TEntity GetById(Guid id) => DbSet.Find(ContextMongoDB.Session, DefaultFilters<TEntity>.EqualsById(id)).SingleOrDefault();

        public TEntity GetById(string id) => DbSet.Find(ContextMongoDB.Session, DefaultFilters<TEntity>.EqualsById(id)).SingleOrDefault();

        public void Remove(TEntity entity) => DbSet.DeleteOneAsync(ContextMongoDB.Session, DefaultFilters<TEntity>.EqualsById(entity));

        public void Remove(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
                Remove(entity);
        }

        public void Update(TEntity entity) => DbSet.ReplaceOneAsync(ContextMongoDB.Session, DefaultFilters<TEntity>.EqualsById(entity.Id), entity);

        public void Update(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
                Update(entity);
        }
    }
}
