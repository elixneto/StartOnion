using System.Threading;
using System.Threading.Tasks;

namespace StartOnion.Application.Commands
{
    public interface ICommandSender
    {
        void Send(Command command);
        void SendAsync(Command command, CancellationToken cancelToken);

        T Send<T>(Command<T> command);
        Task<T> SendAsync<T>(Command<T> command, CancellationToken cancelToken);
    }
}
