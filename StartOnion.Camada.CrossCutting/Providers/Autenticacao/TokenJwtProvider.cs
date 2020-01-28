using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StartOnion.Camada.CrossCutting.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace StartOnion.Camada.CrossCutting.Providers.Autenticacao
{
    public sealed class TokenJwtProvider : ITokenJwtProvider
    {
        private readonly string _chaveDeSeguranca;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenJwtProvider(IConfiguration configuracao)
        {
            var jwtSection = configuracao.GetSection("Jwt");

            if (jwtSection == default)
                throw new JwtNaoConfiguradoException();

            _chaveDeSeguranca = jwtSection["SecurityKey"];
            _issuer = jwtSection["Issuer"];
            _audience = jwtSection["Audience"];

            if(_chaveDeSeguranca == default || _issuer == default || _audience == default)
                throw new JwtNaoConfiguradoException();
        }

        public string GerarToken(string Id, IEnumerable<string> roles)
        {
            var _claimOptions = new IdentityOptions();
            var claims = new List<Claim>();
            claims.Add(new Claim(_claimOptions.ClaimsIdentity.UserIdClaimType, Id));
            claims.AddRange(roles.Select(r=> new Claim(ClaimTypes.Role, r)));

            return new JwtSecurityTokenHandler()
                        .WriteToken(new JwtSecurityToken(
                            issuer: ObterIssuer(),
                            audience: ObterAudience(),
                            expires: DateTime.Now.AddDays(7),
                            signingCredentials: ObterCredenciaisDeAssinatura(),
                            claims: claims));
        }

        public string ObterIssuer() => _issuer;
        public string ObterAudience() => _audience;

        public SymmetricSecurityKey ObterChaveDeSegurancaSimetrica()
            => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_chaveDeSeguranca));

        private SigningCredentials ObterCredenciaisDeAssinatura()
            => new SigningCredentials(ObterChaveDeSegurancaSimetrica(), SecurityAlgorithms.HmacSha256Signature);
    }
}
