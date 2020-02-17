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
            var mensagemEsperada = "O validador não foi informado na classe implementada. Use o construtor que informa o validador.";

            var exception = await Assert.ThrowsAsync<ValidatorNotFoundException>(() => throw new ValidatorNotFoundException());

            Assert.Equal(mensagemEsperada, exception.Message);
        }
    }
}
