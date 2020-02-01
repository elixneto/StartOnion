using StartOnion.Camada.CrossCutting.Utilidades.Validadores;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Utilidades.Validadores
{
    public class ValidadorDeCNPJeste
    {
        [Theory]
        [InlineData("87410734000127")]
        [InlineData("87.410.734/0001-27")]
        public void DeveSerUmCNPJValido(string cnpj)
        {
            Assert.True(new ValidadorDeCNPJ(cnpj).EhValido());
        }

        [Theory]
        [InlineData("8741073400012*123")]
        [InlineData("87.410.734/0001-28")]
        public void DeveSerUmCNPJnvalido(string cnpj)
        {
            Assert.False(new ValidadorDeCNPJ(cnpj).EhValido());
        }
    }
}
