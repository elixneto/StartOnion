using AutoMapper;
using MediatR;

namespace StartOnion.Camada.Aplicacao.ServicosDeAplicacao
{
    public abstract class ServicoDeAplicacao
    {
        protected readonly IMediator _mediador;
        protected readonly IMapper _mapeador;

        public ServicoDeAplicacao(IMediator mediador, IMapper mapeador)
        {
            _mediador = mediador;
            _mapeador = mapeador;
        }
    }
}
