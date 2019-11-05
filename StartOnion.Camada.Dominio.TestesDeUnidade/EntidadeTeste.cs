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

            Assert.True(_entidade.EhValido);
        }
    }
}
