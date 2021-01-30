using MongoDB.Driver;
using StartOnion.Domain;
using StartOnion.Domain.Interfaces;
using StartOnion.Repository.MongoDB.Contexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartOnion.Repository.MongoDB
{
    public abstract class RepositoryMongoDBAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : Entity
    {
        public readonly ContextRepositoryMongoDBAsync ContextMongoDB;
        public readonly IMongoCollection<TEntity> DbSet;
        public readonly FilterDefinitionBuilder<TEntity> Filter;

        protected RepositoryMongoDBAsync(ContextRepositoryMongoDBAsync context, string collectionName)
        {
            ContextMongoDB = context;
            DbSet = ContextMongoDB.Database.GetCollection<TEntity>(collectionName);
            Filter = Builders<TEntity>.Filter;
        }

        public async Task Add(TEntity entity) => await ContextMongoDB.AddCommand(async () => await DbSet.InsertOneAsync(entity));

        public async Task Add(ICollection<TEntity> entities) => await ContextMongoDB.AddCommand(async () => await DbSet.InsertManyAsync(entities));

        public async Task<IEnumerable<TEntity>> GetAll() => (await DbSet.FindAsync(DefaultFilters<TEntity>.Empty())).ToList();

        public async Task<TEntity> GetById(Guid id) => (await DbSet.FindAsync(DefaultFilters<TEntity>.EqualsById(id))).SingleOrDefault();

        public async Task<TEntity> GetById(string id) => (await DbSet.FindAsync(DefaultFilters<TEntity>.EqualsById(id))).SingleOrDefault();

        public async Task Remove(TEntity entity) =>
            await ContextMongoDB.AddCommand(async () => await DbSet.DeleteOneAsync(DefaultFilters<TEntity>.EqualsById(entity)));

        public async Task Remove(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
                await Remove(entity);
        }

        public async Task Update(TEntity entity) => 
            await ContextMongoDB.AddCommand(async () => await DbSet.ReplaceOneAsync(DefaultFilters<TEntity>.EqualsById(entity.Id), entity));

        public async Task Update(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
                await Update(entity);
        }
    }
}
