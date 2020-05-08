using StartOnion.CrossCutting.Exceptions;
using System.Threading.Tasks;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Exceptions
{
    public class JwtNaoConfiguradoExceptionTeste
    {
        [Fact]
        public async Task DeveLancarExcecaoComAMesangemCorreta()
        {
            var mensagemEsperada = "Configure at appsetings.json: \"Jwt\":{ \"SecurityKey\": \"[your_key]\", \"Issuer\": \"[your_issuer]\", \"Audience\":\"[your_audience]\"}";
            
            var exception = await Assert.ThrowsAsync<JwtNotConfiguredException>(() => throw new JwtNotConfiguredException());

            Assert.Equal(mensagemEsperada, exception.Message);
        }
    }
}
