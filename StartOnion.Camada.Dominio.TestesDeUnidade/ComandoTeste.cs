using MediatR;
using StartOnion.Camada.Dominio.TestesDeUnidade.NullObjects;
using Xunit;

namespace StartOnion.Camada.Dominio.TestesDeUnidade
{
    public class ComandoTeste
    {
        private readonly ComandoNull _comando = new ComandoNull();

        [Fact]
        public void ComandoDeveSerUmIBaseRequestDoMediatR()
        {
            Assert.IsAssignableFrom<IBaseRequest>(_comando);
        }
    }
}
