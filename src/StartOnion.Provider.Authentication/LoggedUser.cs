using StartOnion.CrossCutting.Authentication;
using System.Collections.Generic;

namespace StartOnion.Provider.Authentication
{
    public sealed class LoggedUser : ILoggedUser
    {
        public string Id { get; private set; }
        public IDictionary<string, string> Claims { get; private set; }

        public void Set(string id, IDictionary<string, string> claims)
        {
            Id = id;
            Claims = claims;
        }

        public bool IsLogged() => !string.IsNullOrEmpty(Id);
    }
}
