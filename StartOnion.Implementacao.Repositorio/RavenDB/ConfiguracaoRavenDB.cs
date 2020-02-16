using CollectionMapper.RavenDB.NetCore.Interfaces;
using Raven.Client.Documents;

namespace StartOnion.Implementacao.Repositorio.RavenDB
{
    public sealed class ConfiguracaoRavenDB
    {
        public DocumentStore DocumentStore { get; }

        public ConfiguracaoRavenDB(string urlDoBanco, string nomeDoBanco, ICollectionMapperRavenDB mapeador)
        {
            mapeador.IncludeNonPublicProperties();

            DocumentStore = new DocumentStore()
            {
                Urls = new string[] { urlDoBanco },
                Database = nomeDoBanco,
                Conventions = {
                    FindCollectionName = (type) => mapeador.FindCollectionBy(type),
                    JsonContractResolver = mapeador.GetPropertiesContract()
                }
            };
            DocumentStore.Initialize();
        }
    }
}
