using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using StartOnion.Camada.CrossCutting.Notificacoes;
using System.Net;

namespace StartOnion.Implementacao.API.Filtros
{
    public class NotificacaoFiltro : IActionFilter
    {
        private readonly INotificadorContexto _notificador;

        public NotificacaoFiltro(INotificadorContexto notificador)
        {
            _notificador = notificador;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (_notificador.PossuiNotificacoes())
            {
                var resposta = JsonConvert.SerializeObject(_notificador.Notificacoes);

                context.Result = new ObjectResult(resposta)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }
    }
}
