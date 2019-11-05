using MediatR;

namespace StartOnion.Camada.Aplicacao
{
    public abstract class ServicoDeAplicacao
    {
        protected readonly IMediator _mediador;

        public ServicoDeAplicacao(IMediator mediador)
        {
            this._mediador = mediador;
        }
    }
}
