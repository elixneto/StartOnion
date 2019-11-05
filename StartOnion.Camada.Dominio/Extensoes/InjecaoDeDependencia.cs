using Microsoft.Extensions.DependencyInjection;
using StartOnion.Camada.Dominio.Interfaces;

namespace StartOnion.Camada.Dominio.Extensoes
{
    public static class InjecaoDeDependencia
    {
        public static void StartOnionCamadaDominio(this IServiceCollection servicos)
        {
            servicos.AddScoped<INotificador, Notificador>();
        }
    }
}
