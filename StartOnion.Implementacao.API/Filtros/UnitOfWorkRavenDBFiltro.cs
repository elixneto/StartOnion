using Microsoft.AspNetCore.Mvc.Filters;
using StartOnion.Camada.CrossCutting.Notificacoes;
using StartOnion.Implementacao.Repositorio.RavenDB;

namespace StartOnion.Implementacao.API.Filtros
{
    public class UnitOfWorkRavenDBFiltro : IActionFilter
    {
        private readonly INotificadorContexto _notificador;
        private readonly ContextoRepositorioRavenDB _contexto;

        public UnitOfWorkRavenDBFiltro(INotificadorContexto notificador, ContextoRepositorioRavenDB contexto)
        {
            _notificador = notificador;
            _contexto = contexto;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!_notificador.PossuiNotificacoes())
                _contexto.Commit();
            else
                _contexto.Rollback();
        }
    }
}
