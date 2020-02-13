using MediatR;
using StartOnion.Camada.CrossCutting.Notificacoes;
using System.Threading;
using System.Threading.Tasks;

namespace StartOnion.Camada.Aplicacao.Comandos
{
    public abstract class ManipuladorDeComando<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : Comando<TResponse>
    {
        protected readonly INotificadorContexto _notificador;

        public ManipuladorDeComando(INotificadorContexto notificador) { _notificador = notificador;}

        public abstract TResponse Executar(TRequest comando);
        public abstract void Validar(TRequest comando);

        public async Task<TResponse> Handle(TRequest comando, CancellationToken cancellationToken)
        {
            await Task.Run(() => { });

            Validar(comando);
            if (!_notificador.PossuiNotificacoes())
                return Executar(comando);

            return default;
        }
    }
}
