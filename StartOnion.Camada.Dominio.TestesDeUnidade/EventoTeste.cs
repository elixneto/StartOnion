using MediatR;
using Xunit;

namespace StartOnion.Camada.Dominio.TestesDeUnidade
{
    public class EventoTeste
    {
        private readonly Evento _eventoNull = new Evento();

        [Fact]
        public void EventoDeveSerUmINotificationDoMediatR()
        {
            Assert.IsAssignableFrom<INotification>(_eventoNull);
        }
    }
}
