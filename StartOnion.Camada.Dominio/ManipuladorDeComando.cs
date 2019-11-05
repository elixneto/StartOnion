using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StartOnion.Camada.Dominio.Interfaces;

namespace StartOnion.Camada.Dominio
{
    public abstract class ManipuladorDeComando<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : Comando<TResponse>
    {
        protected readonly INotificador _notificador;
        protected readonly IMediator _mediator;

        public ManipuladorDeComando(INotificador notificador, IMediator mediator) { this._notificador = notificador; this._mediator = mediator; }

        public abstract TResponse Executar(TRequest comando);
        protected abstract void Validar(TRequest request);

        public void PublicarEvento(Evento evento) => this._mediator.Publish(evento);

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            await Task.Run(() => { }); // Método é async e espera a keyword await para não dar warning de compilação

            this.Validar(request);
            if (!this._notificador.PossuiNotificacoes)
                return this.Executar(request);

            return default;
        }
    }
}
