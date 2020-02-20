namespace StartOnion.CrossCutting.Providers.Authentication
{
    /// <summary>
    /// JWT Configuration
    /// </summary>
    public sealed class JwtConfiguration
    {
        /// <summary>
        /// Security string key
        /// </summary>
        public string SecurityKey { get; }
        /// <summary>
        /// Issuer
        /// </summary>
        public string Issuer { get; }
        /// <summary>
        /// Audience
        /// </summary>
        public string Audience { get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="securityKey"></param>
        /// <param name="issuer"></param>
        /// <param name="audience"></param>
        public JwtConfiguration(string securityKey, string issuer, string audience)
        {
            SecurityKey = securityKey;
            Issuer = issuer;
            Audience = audience;
        }
    }
}
