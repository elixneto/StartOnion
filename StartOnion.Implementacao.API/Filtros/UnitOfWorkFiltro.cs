using Microsoft.AspNetCore.Mvc.Filters;
using StartOnion.Camada.CrossCutting.Notificacoes;
using StartOnion.Implementacao.Repositorio;

namespace StartOnion.Implementacao.API.Filtros
{
    public class UnitOfWorkFiltro : IActionFilter
    {
        private readonly INotificadorContexto _notificador;

        private readonly BancoDeDadosContexto _contexto;

        public UnitOfWorkFiltro(INotificadorContexto notificador, BancoDeDadosContexto contexto)
        {
            _notificador = notificador;
            _contexto = contexto;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!_notificador.PossuiNotificacoes())
                _contexto.Commit();
            else
                _contexto.Rollback();
        }
    }
}
