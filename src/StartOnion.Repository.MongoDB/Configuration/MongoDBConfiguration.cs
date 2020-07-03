using MongoDB.Driver;

namespace StartOnion.Repository.MongoDB.Configuration
{
    public class MongoDBConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public readonly IMongoClient Client;
        public readonly IMongoDatabase Database;

        public MongoDBConfiguration(string connectionString, string databaseName)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;
            Client = new MongoClient(connectionString);
            Database = Client.GetDatabase(databaseName);
        }
    }
}
