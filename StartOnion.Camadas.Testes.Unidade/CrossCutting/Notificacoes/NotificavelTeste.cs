using FluentValidation.Results;
using StartOnion.Camada.CrossCutting.Notificacoes;
using System.Collections.Generic;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Notificacoes
{
    public class NotificavelTeste : Notificavel
    {
        [Fact]
        public void DeveSerAbstract()
        {
            Assert.True(typeof(Notificavel).IsAbstract);
        }

        [Fact]
        public void DeveAdicionarUmaNotificacao()
        {
            var notificacao = "Teste";

            AdicionarNotificacao(notificacao);

            Assert.Equal(1, ObterNotificacoes().Count);
        }

        [Fact]
        public void DeveAdicionarMaisDeUmaNotificacao()
        {
            var notificacoes = new List<ValidationFailure> { new ValidationFailure("p", "erro 1"), new ValidationFailure("p", "erro 2")};

            AdicionarNotificacoes(notificacoes);

            Assert.Equal(2, ObterNotificacoes().Count);
        }
    }
}
