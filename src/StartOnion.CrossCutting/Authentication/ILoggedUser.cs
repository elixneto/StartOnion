using System.Collections.Generic;

namespace StartOnion.CrossCutting.Authentication
{
    public interface ILoggedUser
    {
        string Id { get; }
        IDictionary<string, string> Claims { get; }

        void Set(string id, IDictionary<string, string> claims);
        bool IsLogged();
    }
}
