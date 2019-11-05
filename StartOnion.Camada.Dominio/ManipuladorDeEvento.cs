using MediatR;
using StartOnion.Camada.Dominio.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace StartOnion.Camada.Dominio
{
    public abstract class ManipuladorDeEvento<T> : INotificationHandler<T> where T : Evento
    {
        private readonly IRepositorioDeEvento _repositorio;

        public ManipuladorDeEvento(IRepositorioDeEvento repositorio) { this._repositorio = repositorio; }

        public Task Handle(T evento, CancellationToken cancellationToken)
        {
            if (evento.EhArmazenavel)
                _repositorio.Armazenar(evento);

            return Task.CompletedTask;
        }
    }
}
