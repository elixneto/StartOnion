using AutoMapper;
using CollectionMapper.RavenDB.NetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;
using StartOnion.Camada.CrossCutting.Notificacoes;
using StartOnion.Implementacao.Repositorio;
using System.Reflection;

namespace StartOnion.InjecaoDeDependencia
{
    public static class InjetorDeServiceCollection
    {
        public static IServiceCollection AddStartOnionAplicacao(this IServiceCollection services, Assembly assemblyDosManipuladoresDeComando, Assembly assemblyDosMapeadores)
        {
            services.AddMediatR(assemblyDosManipuladoresDeComando);
            services.AddAutoMapper(assemblyDosMapeadores);

            return services;
        }

        public static IServiceCollection AddStartOnionCrossCutting(this IServiceCollection services)
        {
            services.AddScoped<INotificadorContexto, NotificadorContexto>();

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
