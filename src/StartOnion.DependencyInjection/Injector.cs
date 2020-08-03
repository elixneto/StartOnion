﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Raven.Client.Documents;
using StartOnion.CrossCutting.Notifications;
using StartOnion.CrossCutting.Providers.Authentication;
using StartOnion.Repository.LiteDB.Configurations;
using StartOnion.Repository.LiteDB.Contexts;
using StartOnion.Repository.MongoDB.Configuration;
using StartOnion.Repository.MongoDB.Contexts;
using StartOnion.Repository.RavenDB.Configurations;
using StartOnion.Repository.RavenDB.Contexts;
using System.Reflection;

namespace StartOnion.DependencyInjection
{
    public static class Injector
    {
        public static IServiceCollection AddStartOnionApplication(this IServiceCollection services, Assembly[] handlersAssembly)
        {
            services.AddMediatR(handlersAssembly);

            return services;
        }

        public static IServiceCollection AddStartOnionCrossCutting(this IServiceCollection services, JwtConfiguration configurationJwt = default)
        {
            if (configurationJwt != default)
            {
                var provedorDeTokenJwt = new TokenJwtProvider(configurationJwt);
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
                            ValidIssuer = provedorDeTokenJwt.GetIssuer(),
                            ValidAudience = provedorDeTokenJwt.GetAudience(),
                            IssuerSigningKey = provedorDeTokenJwt.GetSymmetricSecurityKey()
                        };
                    });
                services.AddSingleton(configurationJwt);
                services.AddSingleton<ITokenJwtProvider, TokenJwtProvider>();
            }

            services.AddScoped<INotificationContext, NotificationContext>();

            return services;
        }

        public static IServiceCollection AddStartOnionRepositoryRavenDB(this IServiceCollection services, RavenDBConfiguration config)
        {
            services.AddSingleton<IDocumentStore>(config.DocumentStore);
            services.AddScoped<ContextRepositoryRavenDB>();
            services.AddScoped<ContextRepositoryRavenDBAsync>();

            return services;
        }

        public static IServiceCollection AddStartOnionRepositoryLiteDB(this IServiceCollection services, LiteDBConfiguration config)
        {
            services.AddSingleton(config);
            services.AddScoped<ContextRepositoryLiteDB>();

            return services;
        }

        public static IServiceCollection AddStartOnionRepositoryMongoDB(this IServiceCollection services, MongoDBConfiguration config)
        {
            services.AddSingleton(config);
            services.AddScoped<ContextRepositoryMongoDBAsync>();

            return services;
        }
    }
}
