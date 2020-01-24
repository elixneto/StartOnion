using StartOnion.Camada.CrossCutting.Testes.Extensoes;
using StartOnion.Camada.Dominio.TestesDeUnidade.NullObjects;
using System;
using Xunit;

namespace StartOnion.Camada.Dominio.TestesDeUnidade
{
    public class EntidadeTeste
    {
        private readonly Entidade _entidade = new EntidadeNull();

        [Fact]
        public void EntidadeDeveSerNotificavel()
        {
            Assert.IsAssignableFrom<Notificavel>(_entidade);
        }

        [Fact]
        public void IdDaEntidadeDeveSerUmGuid()
        {
            Guid guidDeSaida;
            bool ehGuid = Guid.TryParse(_entidade.Id, out guidDeSaida);

            Assert.True(ehGuid);
        }

        [Fact]
        public void DeveChamarOValidadorNoConstrutor()
        {
            var _entidade = new EntidadeNull();

            Assert.True(_entidade.EhValido());
        }

        [Fact]
        public void DeveRetornarVerdadeiroParaEntidadesComMesmoId()
        {
            var entidade1 = new EntidadeNull();
            entidade1.ComValor(() => entidade1.Id, "1");
            var entidade2 = new EntidadeNull();
            entidade2.ComValor(() => entidade2.Id, "1");

            Assert.True(entidade1 == entidade2);
        }

        [Fact]
        public void DeveRetornarFalsoParaEntidadesComIdDiferente()
        {
            var entidade1 = new EntidadeNull();
            entidade1.ComValor(() => entidade1.Id, "1");
            var entidade2 = new EntidadeNull();
            entidade2.ComValor(() => entidade2.Id, "2");

            Assert.False(entidade1 == entidade2);
        }
    }
}
