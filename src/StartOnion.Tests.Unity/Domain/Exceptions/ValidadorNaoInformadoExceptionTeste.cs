using StartOnion.Domain.Exceptions;
using System.Threading.Tasks;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.Dominio.Exceptions
{
    public class ValidadorNaoInformadoExceptionTeste
    {
        [Fact]
        public async Task DeveConterAMensagemCorretaAoLancarAExcecao()
        {
            var mensagemEsperada = "The validator wasn't found. Use the correct constructor.";

            var exception = await Assert.ThrowsAsync<ValidatorNotFoundException>(() => throw new ValidatorNotFoundException());

            Assert.Equal(mensagemEsperada, exception.Message);
        }
    }
}
