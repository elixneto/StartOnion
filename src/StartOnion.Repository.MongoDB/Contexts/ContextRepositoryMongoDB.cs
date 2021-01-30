using MongoDB.Driver;
using StartOnion.Repository.MongoDB.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StartOnion.Repository.MongoDB.Contexts
{
    public class ContextRepositoryMongoDB
    {
        public IMongoClient Client { get; private set; }
        public IMongoDatabase Database { get; set; }
        public IClientSession Session { get; private set; }

        private readonly List<Func<Task>> _commands;

        public ContextRepositoryMongoDB(MongoDBConfiguration configuration)
        {
            Client = configuration.Client;
            Database = configuration.Database;
            _commands = new List<Func<Task>>();
        }

        public void AddCommand(Func<Task> command) => _commands.Add(command);

        public async void Commit()
        {
            using (Session = Client.StartSession())
            {
                Session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }
        }

        public void Rollback()
        {
            while (Session != null && Session.IsInTransaction)
                Thread.Sleep(TimeSpan.FromMilliseconds(100));

            GC.SuppressFinalize(this);
        }
    }
}
