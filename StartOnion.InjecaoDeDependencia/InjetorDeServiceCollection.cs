using AutoMapper;
using CollectionMapper.RavenDB.NetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;
using StartOnion.Camada.Dominio;
using StartOnion.Camada.Dominio.Interfaces;
using StartOnion.Implementacao.Repositorio;
using System.Reflection;

namespace StartOnion.InjecaoDeDependencia
{
    public static class InjetorDeServiceCollection
    {
        public static IServiceCollection AddStarOnionAplicacao(this IServiceCollection services, Assembly assemblyMediator, Assembly assemblyAutoMapper)
        {
            services.AddMediatR(assemblyMediator);
            services.AddAutoMapper(assemblyAutoMapper);

            return services;
        }

        public static IServiceCollection AddStartOnionDominio(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();

            return services;
        }

        public static IServiceCollection AddStartOnionRepositorio(this IServiceCollection services, string urlDoBanco, string nomeDoBanco, CollectionMapperRavenDB mapeadorDeColecoes)
        {
            services.AddSingleton<IDocumentStore>(new ConfiguracaoDoBancoDeDados(urlDoBanco, nomeDoBanco, mapeadorDeColecoes).DocumentStore);
            services.AddScoped<ContextoDoBancoDeDados>();

            return services;
        }
    }
}
