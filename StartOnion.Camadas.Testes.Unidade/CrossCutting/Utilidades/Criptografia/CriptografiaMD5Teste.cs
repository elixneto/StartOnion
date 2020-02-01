using StartOnion.Camada.CrossCutting.Utilidades.Criptografia;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Utilidades.Criptografia
{
    public class CriptografiaMD5Teste
    {
        [Fact]
        public void DeveCriptografarMaiusculo()
        {
            var stringEsperada = "C4CA4238A0B923820DCC509A6F75849B";

            var stringObtida = CriptografiaMD5.ConverterTexto("1", true);

            Assert.Equal(stringEsperada, stringObtida);
        }

        [Fact]
        public void DeveCriptografarMinusculo()
        {
            var stringEsperada = "c4ca4238a0b923820dcc509a6f75849b";

            var stringObtida = CriptografiaMD5.ConverterTexto("1");

            Assert.Equal(stringEsperada, stringObtida);
        }
    }
}
