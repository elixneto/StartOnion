using MediatR;
using StartOnion.CrossCutting.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace StartOnion.Application.Commands
{
    public abstract class Handler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : Command<TResponse>
    {
        protected readonly INotificationContext _notificator;

        public Handler(INotificationContext notificator) { _notificator = notificator; }

        public abstract Task<TResponse> HandleCommand(TRequest command, CancellationToken cancellationToken);
        public abstract Task PreHandleCommand(TRequest command);

        public async Task<TResponse> Handle(TRequest command, CancellationToken cancellationToken)
        {
            await PreHandleCommand(command);

            if (_notificator.HasNotifications())
                return default;

            return await HandleCommand(command, cancellationToken);
        }
    }
}
