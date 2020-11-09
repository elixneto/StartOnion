using Microsoft.AspNetCore.Mvc.Filters;
using StartOnion.Provider.Authentication;
using StartOnion.Provider.Authentication.Jwt;
using System.Collections.Generic;

namespace StartOnion.Api.Filters
{
    public class LoggedUserFilter : IActionFilter
    {
        private readonly ILoggedUser _loggedUser;
        private readonly ITokenJwtProvider _tokenJwtProvider;

        public LoggedUserFilter(ILoggedUser loggedUser, ITokenJwtProvider tokenJwtProvider)
        {
            _loggedUser = loggedUser;
            _tokenJwtProvider = tokenJwtProvider;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var tokenJwt = context.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(tokenJwt))
                return;

            tokenJwt = tokenJwt.ToString().Replace("Bearer", "").Trim();
            var tokenJwtObject = _tokenJwtProvider.GetJwtSecurityTokenObject(tokenJwt);
            if (tokenJwtObject == default || string.IsNullOrEmpty(tokenJwtObject.Subject))
                return;

            var dictionaryClaims = new Dictionary<string, string>();
            foreach (var claim in tokenJwtObject.Claims)
                dictionaryClaims.Add(claim.Type, claim.Value);

            _loggedUser.Set(tokenJwtObject.Subject, dictionaryClaims);
        }
    }
}
