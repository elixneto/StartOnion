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

        public abstract TResponse Handle(TRequest command);
        public abstract void PreHandling(TRequest command);

        public async Task<TResponse> Handle(TRequest command, CancellationToken cancellationToken)
        {
            await Task.Run(() => { });

            PreHandling(command);

            if (_notificator.HasNotifications())
                return default;

            return Handle(command);
        }
    }
}
