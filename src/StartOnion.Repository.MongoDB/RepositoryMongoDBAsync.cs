﻿using MongoDB.Driver;
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

        protected RepositoryMongoDBAsync(ContextRepositoryMongoDBAsync context, string collectionName)
        {
            ContextMongoDB = context;
            DbSet = ContextMongoDB.Database.GetCollection<TEntity>(collectionName);
        }

        public async Task Add(TEntity entity) => await ContextMongoDB.AddCommand(async () => await DbSet.InsertOneAsync(entity));

        public async Task Add(ICollection<TEntity> entities) => await ContextMongoDB.AddCommand(async () => await DbSet.InsertManyAsync(entities));

        public async Task<IEnumerable<TEntity>> GetAll() => (await DbSet.FindAsync(DefaultFilters<TEntity>.Empty())).ToList();

        public async Task<TEntity> GetById(Guid id) => (await DbSet.FindAsync(DefaultFilters<TEntity>.EqualsById(id))).SingleOrDefault();

        public async Task Remove(TEntity entity) => await ContextMongoDB.AddCommand(async () => await DbSet.DeleteOneAsync(DefaultFilters<TEntity>.EqualsById(entity)));

        public async Task Remove(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
                await Remove(entity);
        }
    }
}
