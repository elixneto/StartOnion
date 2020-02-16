using Microsoft.AspNetCore.Mvc.Filters;
using StartOnion.Camada.CrossCutting.Notificacoes;
using StartOnion.Implementacao.Repositorio.LiteDB;

namespace StartOnion.Implementacao.API.Filtros
{
    public class UnitOfWorkLiteDBFiltro : IActionFilter
    {
        private readonly INotificadorContexto _notificador;
        private readonly ContextoRepositorioLiteDB _contexto;

        public UnitOfWorkLiteDBFiltro(INotificadorContexto notificador, ContextoRepositorioLiteDB contexto)
        {
            _notificador = notificador;
            _contexto = contexto;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _contexto.AbrirSessao();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!_notificador.PossuiNotificacoes())
                _contexto.Commit();
            else
                _contexto.Rollback();
            _contexto.Dispose();
        }
    }
}
