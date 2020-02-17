using MediatR;

namespace StartOnion.Application.Commands
{
    public abstract class Command<T> : IRequest<T> { }
}
