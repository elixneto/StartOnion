using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace StartOnion.Application.Commands
{
    public sealed class CommandSender : ICommandSender
    {
        private readonly IMediator _mediator;

        public CommandSender(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Send(Command command) => _mediator.Send(command);

        public T Send<T>(Command<T> command) => _mediator.Send(command).Result;

        public async void SendAsync(Command command, CancellationToken cancelToken) => await _mediator.Send(command, cancelToken);

        public async Task<T> SendAsync<T>(Command<T> command, CancellationToken cancelToken) => await _mediator.Send(command, cancelToken);
    }
}
