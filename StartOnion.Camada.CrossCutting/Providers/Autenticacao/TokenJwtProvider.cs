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
            _chaveDeSeguranca = configuracao?.GetSection("Jwt")?["SecurityKey"];
            _issuer = configuracao?.GetSection("Jwt")?["Issuer"];
            _audience = configuracao?.GetSection("Jwt")?["Audience"];

            if (_chaveDeSeguranca == default || _issuer == default || _audience == default)
                throw new JwtNaoConfiguradoException();
        }

        /// <summary>
        /// Retorna o token JWT
        /// </summary>
        /// <param name="Id">Identificador único do usuário</param>
        /// <returns></returns>
        public string GerarToken(string Id)
            => GerarTokenJwt(Id, null, null, null);
        /// <summary>
        /// Retorna o token JWT
        /// </summary>
        /// <param name="Id">Identificador único do usuário</param>
        /// <param name="dataDeExpiracao">Data de expiração do token</param>
        /// <returns></returns>
        public string GerarToken(string Id, DateTime? dataDeExpiracao)
            => GerarTokenJwt(Id, null, null, dataDeExpiracao);
        /// <summary>
        /// Retorna o token JWT
        /// </summary>
        /// <param name="Id">Identificador único do usuário</param>
        /// <param name="roles">Lista de roles a serem incluídas como claims</param>
        /// /// <param name="dataDeExpiracao">Data de expiração do token</param>
        /// <returns></returns>
        public string GerarToken(string Id, IEnumerable<string> roles, DateTime? dataDeExpiracao)
            => GerarTokenJwt(Id, null, roles, dataDeExpiracao);
        /// <summary>
        /// Retorna o token JWT
        /// </summary>
        /// <param name="Id">Identificador único do usuário</param>
        /// <param name="customClaims">Claims personalizados</param>
        /// <param name="roles">Lista de roles a serem incluídas como claims</param>
        /// <param name="dataDeExpiracao">Data de expiração do token</param>
        /// <returns></returns>
        public string GerarToken(string Id, IDictionary<string, string> claimsPersonalizados, IEnumerable<string> roles, DateTime? dataDeExpiracao)
            => GerarTokenJwt(Id, claimsPersonalizados, roles, dataDeExpiracao);
        

        private string GerarTokenJwt(string Id, IDictionary<string, string> customClaims, IEnumerable<string> roles, DateTime? dataDeExpiracao)
        {
            var _claimOptions = new IdentityOptions();
            var claims = new List<Claim>();
            claims.Add(new Claim("sub", Id));
            if (customClaims != null)
                claims.AddRange(customClaims.Select(c => new Claim(c.Key, c.Value)));
            if (roles != null)
                claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            return new JwtSecurityTokenHandler()
                        .WriteToken(new JwtSecurityToken(
                            issuer: ObterIssuer(),
                            audience: ObterAudience(),
                            expires: dataDeExpiracao,
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
            => new SigningCredentials(ObterChaveDeSegurancaSimetrica(), "HS256");
    }
}
