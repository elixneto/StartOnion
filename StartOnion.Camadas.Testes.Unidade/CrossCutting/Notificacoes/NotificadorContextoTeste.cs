using StartOnion.Camada.CrossCutting.Notificacoes;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Notificacoes
{
    public class NotificadorContextoTeste
    {
        private readonly INotificadorContexto _notificador = new NotificadorContexto();

        [Fact]
        public void DeveAdicionarUmaMensagemPorString()
        {
            var mensagem = "Mensagem";

            _notificador.Adicionar(mensagem);

            Assert.Equal(1, _notificador.Notificacoes.Count);
            Assert.Equal(mensagem, _notificador.Notificacoes.First());
        }

        [Fact]
        public void DeveAdicionarMensagensPorColecaoDeStrings()
        {
            var mensagens = new List<string> { "Mensagem 1", "Mensagem 2" };

            _notificador.Adicionar(mensagens);

            Assert.Equal(2, _notificador.Notificacoes.Count);
            Assert.Equal(mensagens, _notificador.Notificacoes);
        }

        class ClasseNotificavel : Notificavel { public ClasseNotificavel(IEnumerable<string> mensagens) { foreach (var m in mensagens) AdicionarNotificacao(m); } }

        [Fact]
        public void DeveAdicionarMensagensPorClasseNotificavel()
        {
            var mensagens = new List<string> { "Mensagem 1", "Mensagem 2" };
            var classe = new ClasseNotificavel(mensagens);

            _notificador.Adicionar(classe);

            Assert.Equal(2, _notificador.Notificacoes.Count);
            Assert.Equal(mensagens, _notificador.Notificacoes);
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

            _notificador.Adicionar(primeiraClasse, segundaClasse);

            Assert.Equal(4, _notificador.Notificacoes.Count);
            Assert.Equal(conjuntoDeMensagens, _notificador.Notificacoes);
        }

        [Fact]
        public void DeveRetornarVerdadeiroSePossuiNotificacoes()
        {
            var mensagem = "Mensagem";

            _notificador.Adicionar(mensagem);

            Assert.True(_notificador.PossuiNotificacoes());
        }

        [Fact]
        public void DeveRetornarFalsoSeNaoPossuiNotificacoes()
        {
            Assert.False(_notificador.PossuiNotificacoes());
        }
    }
}
