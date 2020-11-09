using System.Collections.Generic;

namespace StartOnion.Provider.Authentication
{
    public interface ILoggedUser
    {
        string Id { get; }
        IDictionary<string, string> Claims { get; }

        void Set(string id, IDictionary<string, string> claims);
        bool IsLogged();
    }
}
