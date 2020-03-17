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

        private readonly ITokenJwtProvider _provider;

        public TokenJwtProviderTeste()
        {
            _chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_chaveDeSeguranca));
            _provider = new TokenJwtProvider(new JwtConfiguration(_chaveDeSeguranca, _issuer, _audience));
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
