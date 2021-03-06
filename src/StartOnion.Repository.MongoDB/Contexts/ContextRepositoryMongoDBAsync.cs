﻿using MongoDB.Driver;
using StartOnion.Repository.MongoDB.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StartOnion.Repository.MongoDB.Contexts
{
    public class ContextRepositoryMongoDBAsync : IContextRepositoryMongoDBAsync
    {
        public IMongoClient Client { get; private set; }
        public IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; private set; }

        private readonly List<Func<Task>> _commands;

        public ContextRepositoryMongoDBAsync(MongoDBConfiguration configuration)
        {
            Client = configuration.Client;
            Database = configuration.Database;
            Session = Client.StartSession();
            _commands = new List<Func<Task>>();
        }

        public async Task AddCommand(Func<Task> command) => await Task.Run(() => _commands.Add(command));

        public async Task Commit()
        {
            Session.StartTransaction();

            var commandTasks = _commands.Select(c => c());

            await Task.WhenAll(commandTasks);

            await Session.CommitTransactionAsync();
            Session.Dispose();
        }

        public void Rollback()
        {
            while (Session != null && Session.IsInTransaction)
                Thread.Sleep(TimeSpan.FromMilliseconds(100));

            Session.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
