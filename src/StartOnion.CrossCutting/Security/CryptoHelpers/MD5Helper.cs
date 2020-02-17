using System.Security.Cryptography;
using System.Text;

namespace StartOnion.CrossCutting.Security.CryptoHelpers
{
    /// <summary>
    /// MD5 Crypto
    /// </summary>
    public static class MD5Helper
    {
        /// <summary>
        /// Convert text to MD5
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="uppercase">Return is uppercase</param>
        /// <returns></returns>
        public static string Get(string text, bool uppercase = false)
        {
            byte[] data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString(uppercase ? "X2" : "x2"));

            return sBuilder.ToString();
        }
    }
}
