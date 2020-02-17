using StartOnion.CrossCutting.Utilities.Helpers;
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
            Assert.True(new EmailHelper(email).IsValid());
        }

        [Theory]
        [InlineData("elixneto@")]
        [InlineData("elixneto.com")]
        [InlineData("a@b.c")]
        public void DeveSerUmEmailInvalido(string email)
        {
            Assert.False(new EmailHelper(email).IsValid());
        }
    }
}
