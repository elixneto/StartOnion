using System;

namespace StartOnion.Camada.CrossCutting.Exceptions
{
    public class JwtNaoConfiguradoException : Exception
    {
        public JwtNaoConfiguradoException() : base("Configure no appsetings.json: \"Jwt\":{ \"SecurityKey\": \"suachave\", \"Issuer\": \"seuissuer\", \"Audience\":\"seuaudience\"}")
        {

        }
    }
}
