using MongoDB.Driver;
using StartOnion.Repository.MongoDB.Configuration;
using System;
using System.Threading;

namespace StartOnion.Repository.MongoDB.Contexts
{
    public class ContextRepositoryMongoDB : IContextRepositoryMongoDB
    {
        public IMongoClient Client { get; private set; }
        public IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; private set; }

        public ContextRepositoryMongoDB(MongoDBConfiguration configuration)
        {
            Client = configuration.Client;
            Database = configuration.Database;
            Session = Client.StartSession();
            Session.StartTransaction();
        }

        public void Commit()
        {
            Session.CommitTransaction();
            Session.Dispose();
        }

        public void Rollback()
        {
            while (Session != null && Session.IsInTransaction)
                Thread.Sleep(TimeSpan.FromMilliseconds(100));

            Session.AbortTransaction();
            Session.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
