using CollectionMapper.RavenDB.NetCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;
using StartOnion.Camada.Dominio.Interfaces;
using StartOnion.Implementacao.Repositorio;

namespace StartOnion.InjecaoDeDependencia.Repositorio
{
    public static class InjecaoDeDependenciaExtensoes
    {
        public static void AddStartOnionRepositorio(this IServiceCollection servicos, string urlDoBanco, string nomeDoBanco, ICollectionMapperRavenDB mapeadorDeColecoes)
        {
            servicos.AddSingleton<IDocumentStore>(new ConfiguracaoDoBancoDeDados(urlDoBanco, nomeDoBanco, mapeadorDeColecoes).DocumentStore);

            servicos.AddScoped<ContextoDoBancoDeDados>();
            servicos.AddScoped<IRepositorioDeEvento, RepositorioDeEvento>();
        }
    }
}
