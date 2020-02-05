using StartOnion.Camada.CrossCutting.Seguranca;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Seguranca
{
    public class GeradorDeSaltTeste
    {
        [Fact]
        public void DeveGerarUmSaltCom12Caracteres()
        {
            var salt = GeradorDeSalt.Gerar(12);

            Assert.Equal(12, salt.Length);
        }
    }
}
