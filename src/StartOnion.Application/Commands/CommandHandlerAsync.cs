using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace StartOnion.Application.Commands
{
    public abstract class CommandHandlerAsync<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : Command<TResponse>
    {
        public abstract Task<TResponse> HandleCommand(TRequest command, CancellationToken cancelToken);

        async Task<TResponse> IRequestHandler<TRequest, TResponse>.Handle(TRequest request, CancellationToken cancellationToken) =>
            await HandleCommand(request, cancellationToken);
    }

    public abstract class CommandHandlerAsync<TRequest> : IRequestHandler<TRequest, Unit>
        where TRequest : Command
    {
        public abstract Task HandleCommand(TRequest command, CancellationToken cancelToken);

        async Task<Unit> IRequestHandler<TRequest, Unit>.Handle(TRequest request, CancellationToken cancellationToken)
        {
            await HandleCommand(request, cancellationToken);
            return default;
        }
    }
}
