using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Raven.Client.Documents;
using StartOnion.Camada.CrossCutting.Notificacoes;
using StartOnion.Camada.CrossCutting.Providers.Autenticacao;
using StartOnion.Implementacao.Repositorio.LiteDB;
using StartOnion.Implementacao.Repositorio.RavenDB;
using StartOnion.InjecaoDeDependencia.Exceptions;
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
                        RequireSignedTokens = true,
                        RequireExpirationTime = false,
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

        public static IServiceCollection AddStartOnionRepositorio(this IServiceCollection services, ConfiguracoesDoBancoDeDados configuracoesDoBancoDeDados)
        {
            if (configuracoesDoBancoDeDados == default)
                throw new ConfiguracoesDoBancoDeDadosException();

            if (configuracoesDoBancoDeDados.UseRavenDB)
                services.InjetarRavenDB(configuracoesDoBancoDeDados);

            if (configuracoesDoBancoDeDados.UseLiteDB)
                services.InjetarLiteDB(configuracoesDoBancoDeDados);

            return services;
        }

        private static IServiceCollection InjetarRavenDB(this IServiceCollection services, ConfiguracoesDoBancoDeDados configuracoes)
        {
            if (configuracoes.UrlDoBanco == default)
                throw new UrlDoBancoDeDadosNaoInformadoException();
            if (configuracoes.NomeDoBanco == default)
                throw new NomeDoBancoDeDadosNaoInformadoException();
            if (configuracoes.MapeadorDeColecoesRavenDB == default)
                throw new MapeadorDeColecoesDoRavenDBNaoInformadoException();

            services.AddSingleton<IDocumentStore>(new ConfiguracaoRavenDB(configuracoes.UrlDoBanco,
                                                                          configuracoes.NomeDoBanco,
                                                                          configuracoes.MapeadorDeColecoesRavenDB).DocumentStore);
            services.AddScoped<ContextoRepositorioRavenDB>();
            services.AddScoped<ContextoQueryRavenDB>();

            return services;
        }
        private static IServiceCollection InjetarLiteDB(this IServiceCollection services, ConfiguracoesDoBancoDeDados configuracoes)
        {
            if (configuracoes.ConexaoLiteDB == default)
                throw new ConexaoDoLiteDBNaoInformadaException();

            services.AddSingleton(new ConfiguracaoLiteDB(configuracoes.ConexaoLiteDB));
            services.AddScoped<ContextoRepositorioLiteDB>();

            return services;
        }
    }
}
