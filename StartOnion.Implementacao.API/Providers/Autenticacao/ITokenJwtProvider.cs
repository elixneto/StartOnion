using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace StartOnion.Implementacao.API.Providers.Autenticacao
{
    public interface ITokenJwtProvider
    {
        string GerarToken(string Id, IEnumerable<string> roles);
        string ObterIssuer();
        string ObterAudience();
        SymmetricSecurityKey ObterChaveDeSegurancaSimetrica();
    }
}
