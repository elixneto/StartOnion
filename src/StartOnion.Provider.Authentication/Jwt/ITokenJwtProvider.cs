using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace StartOnion.Provider.Authentication.Jwt
{
    /// <summary>
    /// Token JWT provider
    /// </summary>
    public interface ITokenJwtProvider
    {
        /// <summary>
        /// Get token JWT
        /// </summary>
        /// <param name="id">Identity</param>
        /// <returns></returns>
        string GenerateToken(string id);
        /// <summary>
        /// Get token JWT
        /// </summary>
        /// <param name="id">Identity</param>
        /// <param name="expirationDate">Expiration date</param>
        /// <returns></returns>
        string GenerateToken(string id, DateTime? expirationDate = null);
        /// <summary>
        /// Get token JWT
        /// </summary>
        /// <param name="id">Identity</param>
        /// <param name="roles">Role claims</param>
        /// /// <param name="expirationDate">Expiration date</param>
        /// <returns></returns>
        string GenerateToken(string id, IEnumerable<string> roles, DateTime? expirationDate = null);
        /// <summary>
        /// Get token JWT
        /// </summary>
        /// <param name="id">Identity</param>
        /// <param name="customClaims">Custom claims</param>
        /// <param name="roles">Role claims</param>
        /// <param name="expirationDate">Expiration date</param>
        /// <returns></returns>
        string GenerateToken(string id, IDictionary<string, string> customClaims, IEnumerable<string> roles, DateTime? expirationDate = null);
        /// <summary>
        /// Get issuer
        /// </summary>
        /// <returns></returns>
        string GetIssuer();
        /// <summary>
        /// Get audience
        /// </summary>
        /// <returns></returns>
        string GetAudience();
        /// <summary>
        /// Get SymmetricSecurityKey
        /// </summary>
        /// <returns></returns>
        SymmetricSecurityKey GetSymmetricSecurityKey();
        /// <summary>
        /// Get JwtSecurityToken by string token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        JwtSecurityToken GetJwtSecurityTokenObject(string token);
    }
}
