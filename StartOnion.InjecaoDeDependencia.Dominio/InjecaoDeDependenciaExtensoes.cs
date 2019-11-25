using Microsoft.Extensions.DependencyInjection;
using StartOnion.Camada.Dominio;
using StartOnion.Camada.Dominio.Interfaces;

namespace StartOnion.InjecaoDeDependencia.Dominio
{
    public static class InjecaoDeDependenciaExtensoes
    {
        public static void AddStartOnionDominio(this IServiceCollection servicos)
        {
            servicos.AddScoped<INotificador, Notificador>();
        }
    }
}
