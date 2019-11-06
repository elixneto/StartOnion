using CollectionMapper.RavenDB.NetCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;
using StartOnion.Camada.Dominio.Interfaces;

namespace StartOnion.Implementacao.Repositorio.Extensoes
{
    public static class InjecaoDeDependencia
    {
        public static void StartOnionImplementacaoRepositorio(this IServiceCollection servicos, string urlDoBanco, string nomeDoBanco, ICollectionMapperRavenDB mapeadorDeColecoes)
        {
            servicos.AddSingleton<IDocumentStore>(new ConfiguracaoDoBancoDeDados(urlDoBanco, nomeDoBanco, mapeadorDeColecoes).DocumentStore);

            servicos.AddScoped<IRepositorioDeEvento, RepositorioDeEvento>();
            servicos.AddScoped<ContextoDoBancoDeDados>();
        }
    }
}
