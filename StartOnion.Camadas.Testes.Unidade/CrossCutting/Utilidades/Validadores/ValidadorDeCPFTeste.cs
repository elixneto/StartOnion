using StartOnion.Camada.CrossCutting.Utilidades.Validadores;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Utilidades.Validadores
{
    public class ValidadorDeCPFTeste
    {
        [Theory]
        [InlineData("04432125110")]
        [InlineData("044.321.251-10")]
        public void DeveSerUmCPFValido(string cpf)
        {
            Assert.True(new ValidadorDeCPF(cpf).EhValido());
        }

        [Theory]
        [InlineData("0443212511*")]
        [InlineData("044.321.251-11")]
        public void DeveSerUmCPFInvalido(string cpf)
        {
            Assert.False(new ValidadorDeCPF(cpf).EhValido());
        }
    }
}
