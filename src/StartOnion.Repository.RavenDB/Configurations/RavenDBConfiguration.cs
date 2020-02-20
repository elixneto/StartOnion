using CollectionMapper.RavenDB.NetCore.Interfaces;
using Raven.Client.Documents;

namespace StartOnion.Repository.RavenDB.Configurations
{
    public sealed class RavenDBConfiguration
    {
        public DocumentStore DocumentStore { get; }

        public RavenDBConfiguration(string[] databaseUrls, string databaseName, ICollectionMapperRavenDB mapper)
        {
            mapper.IncludeNonPublicProperties();

            DocumentStore = new DocumentStore()
            {
                Urls = databaseUrls,
                Database = databaseName,
                Conventions = {
                    FindCollectionName = (type) => mapper.FindCollectionBy(type),
                    JsonContractResolver = mapper.GetPropertiesContract()
                }
            };
            DocumentStore.Initialize();
        }
    }
}
