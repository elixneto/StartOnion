using AutoMapper;
using CollectionMapper.RavenDB.NetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Raven.Client.Documents;
using StartOnion.Camada.CrossCutting.Notificacoes;
using StartOnion.Camada.CrossCutting.Providers.Autenticacao;
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

        public static IServiceCollection AddStartOnionCrossCutting(this IServiceCollection services, IConfiguration configuration)
        {
            var provedorDeTokenJwt = new TokenJwtProvider(configuration);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = provedorDeTokenJwt.ObterIssuer(),
                        ValidAudience = provedorDeTokenJwt.ObterAudience(),
                        IssuerSigningKey = provedorDeTokenJwt.ObterChaveDeSegurancaSimetrica()
                    };
                });

            services.AddSingleton<ITokenJwtProvider, TokenJwtProvider>();

            services.AddScoped<INotificadorContexto, NotificadorContexto>();

            return services;
        }

        public static IServiceCollection AddStartOnionRepositorio(this IServiceCollection services, string urlDoBanco, string nomeDoBanco, CollectionMapperRavenDB mapeadorDeColecoes)
        {
            services.AddSingleton<IDocumentStore>(new ConfiguracaoDoBancoDeDados(urlDoBanco, nomeDoBanco, mapeadorDeColecoes).DocumentStore);
            services.AddScoped<BancoDeDadosContexto>();
            services.AddScoped<QueryContexto>();

            return services;
        }
    }
}
