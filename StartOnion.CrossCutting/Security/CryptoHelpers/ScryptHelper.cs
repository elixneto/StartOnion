using Scrypt;

namespace StartOnion.CrossCutting.Security.CryptoHelpers
{
    /// <summary>
    /// Scrypt Crypto
    /// </summary>
    public static class ScryptHelper
    {
        private const int BLOCK = 8;
        private const int THREADS = 8;
        private const int COST = 16384;

        /// <summary>
        /// Get crypto hash
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string CryptPassword(string pass, string salt)
            => new ScryptEncoder(COST, BLOCK, THREADS).Encode(GetPattern(pass, salt));
        /// <summary>
        /// Get crypto hash
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string CryptText(string text)
            => new ScryptEncoder(COST, BLOCK, THREADS).Encode(text);

        /// <summary>
        /// validate password with salt and hash
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="salt"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool ValidatePassword(string pass, string salt, string hash)
            => new ScryptEncoder(COST, BLOCK, THREADS).Compare(GetPattern(pass, salt), hash);
        /// <summary>
        /// validate text with hash
        /// </summary>
        /// <param name="text">Texto em plain text a ser verificado</param>
        /// <param name="hash">Hash a ser verificado</param>
        /// <returns></returns>
        public static bool ValidateText(string text, string hash)
            => new ScryptEncoder(COST, BLOCK, THREADS).Compare(text, hash);

        private static string GetPattern(string text, string salt)
            => $"0n10n.{text}..{salt}.S4LT";
    }
}
