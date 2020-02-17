using FluentValidation.Results;
using StartOnion.CrossCutting.Notifications;
using System.Collections.Generic;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Notificacoes
{
    public class NotificavelTeste : Notifiable
    {
        [Fact]
        public void DeveSerAbstract()
        {
            Assert.True(typeof(Notifiable).IsAbstract);
        }

        [Fact]
        public void DeveAdicionarUmaNotificacao()
        {
            var notificacao = "Teste";

            AddNotification(notificacao);

            Assert.Equal(1, GetNotifications().Count);
        }

        [Fact]
        public void DeveAdicionarMaisDeUmaNotificacao()
        {
            var notificacoes = new List<ValidationFailure> { new ValidationFailure("p", "erro 1"), new ValidationFailure("p", "erro 2")};

            AddNotifications(notificacoes);

            Assert.Equal(2, GetNotifications().Count);
        }
    }
}
