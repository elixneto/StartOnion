using StartOnion.Camada.CrossCutting.Utilidades.Validadores;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Utilidades.Validadores
{
    public class ValidadorDeEmailTeste
    {
        [Theory]
        [InlineData("elixneto@gmail.com")]
        [InlineData("nome@provedor.com.br")]
        public void DeveSerUmEmailValido(string email)
        {
            Assert.True(new ValidadorDeEmail(email).EhValido());
        }

        [Theory]
        [InlineData("elixneto@")]
        [InlineData("elixneto.com")]
        [InlineData("a@b.c")]
        public void DeveSerUmEmailInvalido(string email)
        {
            Assert.False(new ValidadorDeEmail(email).EhValido());
        }
    }
}
