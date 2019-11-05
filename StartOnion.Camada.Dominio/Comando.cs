using MediatR;

namespace StartOnion.Camada.Dominio
{
    public abstract class Comando<T> : IRequest<T> { }
}
