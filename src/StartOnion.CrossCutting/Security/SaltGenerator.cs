using System;
using System.Security.Cryptography;
using System.Text;

namespace StartOnion.CrossCutting.Security
{
    /// <summary>
    /// Salt generator (based in RNGCryptoServiceProvider)
    /// </summary>
    public static class SaltGenerator
    {
        /// <summary>
        /// Get a random salt
        /// </summary>
        /// <param name="size">Tamanho do salt</param>
        /// <returns></returns>
        public static string Get(int size) => Encoding.UTF8.GetString(GetSalt(size));
        /// <summary>
        /// Get a random salt in bytes
        /// </summary>
        /// <param name="size">Tamanho do salt</param>
        /// <returns></returns>
        public static byte[] GetInBytes(int size) => GetSalt(size);
        /// <summary>
        /// Get a random salt in Base64 string
        /// </summary>
        /// <param name="size">Tamanho do salt</param>
        /// <returns></returns>
        public static string GetInBase64(int size) => Convert.ToBase64String(GetSalt(size));

        private static byte[] GetSalt(int size)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (size-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return Encoding.UTF8.GetBytes(res.ToString());
        }
    }
}
