using StartOnion.CrossCutting.Notifications;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Notificacoes
{
    public class NotificadorContextoTeste
    {
        private readonly INotificationContext _notificador = new NotificationContext();

        [Fact]
        public void DeveAdicionarUmaMensagemPorString()
        {
            var mensagem = "Mensagem";

            _notificador.Add(mensagem);

            Assert.Equal(1, _notificador.Notifications.Count);
            Assert.Equal(mensagem, _notificador.Notifications.First());
        }

        [Fact]
        public void DeveAdicionarMensagensPorColecaoDeStrings()
        {
            var mensagens = new List<string> { "Mensagem 1", "Mensagem 2" };

            _notificador.Add(mensagens);

            Assert.Equal(2, _notificador.Notifications.Count);
            Assert.Equal(mensagens, _notificador.Notifications);
        }

        class ClasseNotificavel : Notifiable { public ClasseNotificavel(IEnumerable<string> mensagens) { foreach (var m in mensagens) AddNotification(m); } }

        [Fact]
        public void DeveAdicionarMensagensPorClasseNotificavel()
        {
            var mensagens = new List<string> { "Mensagem 1", "Mensagem 2" };
            var classe = new ClasseNotificavel(mensagens);

            _notificador.Add(classe);

            Assert.Equal(2, _notificador.Notifications.Count);
            Assert.Equal(mensagens, _notificador.Notifications);
        }

        [Fact]
        public void DeveAdicionarMensagensPorClassesNotificaveis()
        {
            var primeirasMensagens = new List<string> { "Mensagem 1", "Mensagem 2" };
            var primeiraClasse = new ClasseNotificavel(primeirasMensagens);
            var segundasMensagens = new List<string> { "Mensagem 3", "Mensagem 4" };
            var segundaClasse = new ClasseNotificavel(segundasMensagens);
            var conjuntoDeMensagens = new List<string>();
            conjuntoDeMensagens.AddRange(primeirasMensagens);
            conjuntoDeMensagens.AddRange(segundasMensagens);

            _notificador.Add(primeiraClasse, segundaClasse);

            Assert.Equal(4, _notificador.Notifications.Count);
            Assert.Equal(conjuntoDeMensagens, _notificador.Notifications);
        }

        [Fact]
        public void DeveRetornarVerdadeiroSePossuiNotificacoes()
        {
            var mensagem = "Mensagem";

            _notificador.Add(mensagem);

            Assert.True(_notificador.HasNotifications());
        }

        [Fact]
        public void DeveRetornarFalsoSeNaoPossuiNotificacoes()
        {
            Assert.False(_notificador.HasNotifications());
        }
    }
}
