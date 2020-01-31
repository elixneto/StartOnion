using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace StartOnion.Camada.CrossCutting.Providers.Autenticacao
{
    /// <summary>
    /// Provedor de Token JWT
    /// </summary>
    public interface ITokenJwtProvider
    {
        /// <summary>
        /// Retorna o token JWT
        /// </summary>
        /// <param name="Id">Identificador único do usuário</param>
        /// <param name="roles">Lista de roles a serem incluídas como claims</param>
        /// <returns></returns>
        string GerarToken(string Id, IEnumerable<string> roles);
        /// <summary>
        /// Issuer do JWT
        /// </summary>
        /// <returns></returns>
        string ObterIssuer();
        /// <summary>
        /// Audience do JWT
        /// </summary>
        /// <returns></returns>
        string ObterAudience();
        /// <summary>
        /// SymmetricSecurityKey da chave de segurança
        /// </summary>
        /// <returns></returns>
        SymmetricSecurityKey ObterChaveDeSegurancaSimetrica();
        /// <summary>
        /// Obtém a data de expiração do token
        /// </summary>
        /// <param name="dias">Quantidade de dias para expirar</param>
        /// <returns></returns>
        DateTime ObterDataDeExpiracaoPorDias(int dias);
    }
}
