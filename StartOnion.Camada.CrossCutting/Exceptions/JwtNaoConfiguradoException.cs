using System;

namespace StartOnion.Camada.CrossCutting.Exceptions
{
    /// <summary>
    /// Exceção de JWT não configurado
    /// </summary>
    public sealed class JwtNaoConfiguradoException : Exception
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public JwtNaoConfiguradoException() : base("Configure no appsetings.json: \"Jwt\":{ \"SecurityKey\": \"suachave\", \"Issuer\": \"seuissuer\", \"Audience\":\"seuaudience\"}")
        {

        }
    }
}
