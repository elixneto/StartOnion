using System;

namespace StartOnion.Provider.Authentication.Exceptions
{
    /// <summary>
    /// JWT not configured exception
    /// </summary>
    public sealed class JwtNotConfiguredException : Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public JwtNotConfiguredException() : base("Configure at appsetings.json: \"Jwt\":{ \"SecurityKey\": \"[your_key]\", \"Issuer\": \"[your_issuer]\", \"Audience\":\"[your_audience]\"}")
        {

        }
    }
}
