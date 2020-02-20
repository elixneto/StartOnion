﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StartOnion.CrossCutting.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace StartOnion.CrossCutting.Providers.Authentication
{
    /// <summary>
    /// Token JWT provider
    /// </summary>
    public sealed class TokenJwtProvider : ITokenJwtProvider
    {
        private readonly string _securityKey;
        private readonly string _issuer;
        private readonly string _audience;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="config"></param>
        public TokenJwtProvider(JwtConfiguration config)
        {
            _securityKey = config.SecurityKey;
            _issuer = config.Issuer;
            _audience = config.Audience;

            if (_securityKey == default || _issuer == default || _audience == default)
                throw new JwtNotConfiguredException();
        }

        /// <summary>
        /// Get token JWT
        /// </summary>
        /// <param name="id">Identity</param>
        /// <returns></returns>
        public string GenerateToken(string id)
            => GenerateTokenJwt(id, null, null, null);
        /// <summary>
        /// Get token JWT
        /// </summary>
        /// <param name="id">Identity</param>
        /// <param name="expirationDate">Expiration date</param>
        /// <returns></returns>
        public string GenerateToken(string id, DateTime? expirationDate = null)
            => GenerateTokenJwt(id, null, null, expirationDate);
        /// <summary>
        /// Get token JWT
        /// </summary>
        /// <param name="id">Identity</param>
        /// <param name="roles">Role claims</param>
        /// /// <param name="expirationDate">Expiration date</param>
        /// <returns></returns>
        public string GenerateToken(string id, IEnumerable<string> roles, DateTime? expirationDate = null)
            => GenerateTokenJwt(id, null, roles, expirationDate);
        /// <summary>
        /// Get token JWT
        /// </summary>
        /// <param name="id">Identity</param>
        /// <param name="customClaims">Custom claims</param>
        /// <param name="roles">Role claims</param>
        /// <param name="expirationDate">Expiration date</param>
        /// <returns></returns>
        public string GenerateToken(string id, IDictionary<string, string> customClaims, IEnumerable<string> roles, DateTime? expirationDate = null)
            => GenerateTokenJwt(id, customClaims, roles, expirationDate);


        private string GenerateTokenJwt(string id, IDictionary<string, string> customClaims, IEnumerable<string> roles, DateTime? expirationDate = null)
        {
            var claims = new List<Claim> { new Claim("sub", id) };

            if (customClaims != null && customClaims.Any())
                claims.AddRange(customClaims.Select(c => new Claim(c.Key, c.Value)));
            
            if (roles != null && roles.Any())
                claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            return new JwtSecurityTokenHandler()
                        .WriteToken(new JwtSecurityToken(
                            issuer: GetIssuer(),
                            audience: GetAudience(),
                            expires: expirationDate,
                            signingCredentials: GetSigningCredentials(),
                            claims: claims));
        }

        /// <summary>
        /// Get issuer
        /// </summary>
        /// <returns></returns>
        public string GetIssuer() => _issuer;
        /// <summary>
        /// Get audience
        /// </summary>
        /// <returns></returns>
        public string GetAudience() => _audience;

        /// <summary>
        /// Get SymmetricSecurityKey
        /// </summary>
        /// <returns></returns>
        public SymmetricSecurityKey GetSymmetricSecurityKey()
            => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey));

        private SigningCredentials GetSigningCredentials()
            => new SigningCredentials(GetSymmetricSecurityKey(), "HS256");
    }
}
