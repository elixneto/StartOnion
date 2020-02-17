using StartOnion.CrossCutting.Security;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Seguranca
{
    public class GeradorDeSaltTeste
    {
        [Fact]
        public void DeveGerarUmSaltCom12Caracteres()
        {
            var salt = SaltGenerator.Get(12);

            Assert.Equal(12, salt.Length);
        }
    }
}
