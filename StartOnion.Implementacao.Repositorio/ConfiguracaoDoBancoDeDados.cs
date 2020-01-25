using CollectionMapper.RavenDB.NetCore.Interfaces;
using Raven.Client.Documents;

namespace StartOnion.Implementacao.Repositorio
{
    public sealed class ConfiguracaoDoBancoDeDados
    {
        public DocumentStore DocumentStore { get; }

        public ConfiguracaoDoBancoDeDados(string urlDoBanco, string nomeDoBanco, ICollectionMapperRavenDB mapeador)
        {
            mapeador.IgnoreProperties(new string[] { "EhValido", "Notificacoes" }); // Propriedades da Entidade
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
