using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace StartOnion.Application.Commands
{
    public abstract class CommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : Command<TResponse>
    {
        public abstract TResponse HandleCommand(TRequest request);

        Task<TResponse> IRequestHandler<TRequest, TResponse>.Handle(TRequest request, CancellationToken cancellationToken)
            => Task.FromResult(HandleCommand(request));
    }

    public abstract class CommandHandler<TRequest> : IRequestHandler<TRequest, Unit>
        where TRequest : Command
    {
        public abstract void HandleCommand(TRequest request);

        Task<Unit> IRequestHandler<TRequest, Unit>.Handle(TRequest request, CancellationToken cancellationToken)
        {
            HandleCommand(request);
            return default;
        }
    }
}
