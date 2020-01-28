using MediatR;

namespace StartOnion.Camada.Aplicacao.Comandos
{
    public abstract class Comando<T> : IRequest<T> { }
}
