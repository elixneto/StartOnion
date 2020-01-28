using System;

namespace StartOnion.Camada.CrossCutting.Exceptions
{
    public sealed class JwtNaoConfiguradoException : Exception
    {
        public JwtNaoConfiguradoException() : base("Configure no appsetings.json: \"Jwt\":{ \"SecurityKey\": \"suachave\", \"Issuer\": \"seuissuer\", \"Audience\":\"seuaudience\"}")
        {

        }
    }
}
