using Microsoft.IdentityModel.Tokens;
using StartOnion.CrossCutting.Providers.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Providers.Autenticacao
{
    public class TokenJwtProviderTeste
    {
        private string _chaveDeSeguranca = "s3cr3tk3y!!nv38RDmBPcdObV3aA3hEvw1edOOZbxBu";
        private SymmetricSecurityKey _chaveSimetrica;
        private string _issuer = "myissuer";
        private string _audience = "myaudience";
        private string _sub = "1";
        private List<string> _roles = new List<string> { "admin" };
        private DateTime _dataDeExpiracao = new DateTime(2020, 1, 1);

        private readonly string _tokenValido = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiYWRtaW4iLCJleHAiOjE1Nzc4NTEyMDAsImlzcyI6Im15aXNzdWVyIiwiYXVkIjoibXlhdWRpZW5jZSJ9.BShdfLm06PItIgOSS1KT01yZaimFTvcfJXpmMbdKK5Q";
        private readonly ITokenJwtProvider _provider;

        public TokenJwtProviderTeste()
        {
            _chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_chaveDeSeguranca));
            _provider = new TokenJwtProvider(new JwtConfiguration(_chaveDeSeguranca, _issuer, _audience));
        }

        [Fact]
        public void DeveGerarUmTokenJwtValido()
        {
            var tokenGerado = _provider.GenerateToken(_sub, _roles, _dataDeExpiracao);

            Assert.Equal(_tokenValido, tokenGerado);
        }

        [Fact]
        public void DeveRetornarOIssuerCorreto()
        {
            var issuerRetornado = _provider.GetIssuer();

            Assert.Equal(_issuer, issuerRetornado);
        }

        [Fact]
        public void DeveRetornarOAudienceCorreto()
        {
            var audienceRetornado = _provider.GetAudience();

            Assert.Equal(_audience, audienceRetornado);
        }

        [Fact(Skip = "new SymmetricSecurityKey sempre retorna uma chave diferente")]
        public void DeveRetornarAChaveDeSegurancaSimetricaCorreta()
        {
            var chaveSimetricaRetornada = _provider.GetSymmetricSecurityKey();

            Assert.Equal(_chaveSimetrica, chaveSimetricaRetornada);
        }
    }
}
