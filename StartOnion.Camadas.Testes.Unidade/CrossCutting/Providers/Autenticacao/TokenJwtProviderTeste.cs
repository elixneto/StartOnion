using Microsoft.Extensions.Configuration;
using Moq;
using StartOnion.Camada.CrossCutting.Providers.Autenticacao;
using System;
using System.Collections.Generic;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Providers.Autenticacao
{
    public class TokenJwtProviderTeste
    {
        private string _chaveDeSeguranca = "s3cr3tk3y!!nv38RDmBPcdObV3aA3hEvw1edOOZbxBu";
        private string _issuer = "myissuer";
        private string _audience = "myaudience";
        private string _sub = "1";
        private List<string> _roles = new List<string> { "admin" };

        private readonly Mock<IConfiguration> _mockConfiguration = new Mock<IConfiguration>();

        private readonly string _tokenValido = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiYWRtaW4iLCJleHAiOjE1ODEwOTMyNDAsImlzcyI6Im15aXNzdWVyIiwiYXVkIjoibXlhdWRpZW5jZSJ9.tQUgR0Cjas8vozAsRTgGMRN-Uw5QJnuqvgJ7EuSM_Sw";

        public TokenJwtProviderTeste()
        {

        }

        [Fact]
        public void DeveGerarUmTokenJwtValido()
        {
            var mockConfSection = new Mock<IConfigurationSection>();
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "SecurityKey")]).Returns(_chaveDeSeguranca);
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "Issuer")]).Returns(_issuer);
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "Audience")]).Returns(_audience);
            _mockConfiguration.Setup(a => a.GetSection(It.Is<string>(s => s == "Jwt"))).Returns(mockConfSection.Object);
            var mockProvider = new Mock<ITokenJwtProvider>();
            var dataReferencia = new DateTime(2020, 1, 1);
            mockProvider.Setup(s => s.ObterDataDeExpiracaoPorDias(7)).Returns(dataReferencia);

            var tokenGerado = mockProvider.Object.GerarToken(_sub, _roles);

            Assert.Equal(_tokenValido, tokenGerado);
        }
    }
}
