using MediatR;

namespace StartOnion.Application.Commands
{
    public abstract class Command<T> : IRequest<T> { }

    public abstract class Command : IRequest { }
}
