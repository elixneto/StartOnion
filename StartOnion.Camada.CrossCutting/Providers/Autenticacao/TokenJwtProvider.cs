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
    /// <summary>
    /// Provedor de Token JWT
    /// </summary>
    public sealed class TokenJwtProvider : ITokenJwtProvider
    {
        private readonly string _chaveDeSeguranca;
        private readonly string _issuer;
        private readonly string _audience;

        /// <summary>
        /// Construtor padrão com injeção de IConfiguration
        /// </summary>
        /// <param name="configuracao"></param>
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

        /// <summary>
        /// Retorna o token JWT
        /// </summary>
        /// <param name="Id">Identificador único do usuário</param>
        /// <param name="roles">Lista de roles a serem incluídas como claims</param>
        /// <returns></returns>
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

        /// <summary>
        /// Issuer do JWT
        /// </summary>
        /// <returns></returns>
        public string ObterIssuer() => _issuer;
        /// <summary>
        /// Audience do JWT
        /// </summary>
        /// <returns></returns>
        public string ObterAudience() => _audience;

        /// <summary>
        /// SymmetricSecurityKey da chave de segurança
        /// </summary>
        /// <returns></returns>
        public SymmetricSecurityKey ObterChaveDeSegurancaSimetrica()
            => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_chaveDeSeguranca));

        private SigningCredentials ObterCredenciaisDeAssinatura()
            => new SigningCredentials(ObterChaveDeSegurancaSimetrica(), SecurityAlgorithms.HmacSha256Signature);
    }
}
