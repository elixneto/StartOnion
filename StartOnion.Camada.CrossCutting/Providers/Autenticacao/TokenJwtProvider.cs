﻿using Microsoft.AspNetCore.Identity;
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
        /// <param name="roles">Lista de roles a serem incluídas como claims</param>
        /// <returns></returns>
        public string GerarToken(string Id, IEnumerable<string> roles)
        {
            var _claimOptions = new IdentityOptions();
            var claims = new List<Claim>();
            claims.Add(new Claim("sub", Id));
            //if (roles != null)
                claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            return new JwtSecurityTokenHandler()
                        .WriteToken(new JwtSecurityToken(
                            issuer: ObterIssuer(),
                            audience: ObterAudience(),
                            expires: ObterDataDeExpiracaoPorDias(7),
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
        /// Obtém a data de expiração do token
        /// </summary>
        /// <param name="dias">Quantidade de dias para expirar</param>
        /// <returns></returns>
        public DateTime ObterDataDeExpiracaoPorDias(int dias)
            => new DateTime(DateTime.Now.AddDays(dias).Year, DateTime.Now.AddDays(dias).Month, DateTime.Now.AddDays(dias).Day, 23, 59, 59);

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
