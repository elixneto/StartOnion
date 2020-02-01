﻿using StartOnion.Camada.CrossCutting.Exceptions;
using System.Threading.Tasks;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Exceptions
{
    public class JwtNaoConfiguradoExceptionTeste
    {
        [Fact]
        public async Task DeveLancarExcecaoComAMesangemCorreta()
        {
            var mensagemEsperada = "Configure no appsetings.json: \"Jwt\":{ \"SecurityKey\": \"suachave\", \"Issuer\": \"seuissuer\", \"Audience\":\"seuaudience\"}";
            
            var exception = await Assert.ThrowsAsync<JwtNaoConfiguradoException>(() => throw new JwtNaoConfiguradoException());

            Assert.Equal(mensagemEsperada, exception.Message);
        }
    }
}
