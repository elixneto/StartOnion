using System;
using System.Security.Cryptography;
using System.Text;

namespace StartOnion.Camada.CrossCutting.Seguranca
{
    /// <summary>
    /// Gerador de salt (baseado em <code>RNGCryptoServiceProvider</code>)
    /// </summary>
    public static class GeradorDeSalt
    {
        /// <summary>
        /// Gera um salt aleatório e retorna em string
        /// </summary>
        /// <param name="tamanho">Tamanho do salt</param>
        /// <returns></returns>
        public static string Gerar(int tamanho) => Encoding.UTF8.GetString(GerarSalt(tamanho));
        /// <summary>
        /// Gera um salt aleatório e retorna em bytes
        /// </summary>
        /// <param name="tamanho">Tamanho do salt</param>
        /// <returns></returns>
        public static byte[] GerarEmBytes(int tamanho) => GerarSalt(tamanho);
        /// <summary>
        /// Gera um salt aleatório e retorna em string codificado em Base64
        /// </summary>
        /// <param name="tamanho">Tamanho do salt</param>
        /// <returns></returns>
        public static string GerarEmBase64(int tamanho) => Convert.ToBase64String(GerarSalt(tamanho));

        private static byte[] GerarSalt(int tamanho)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (tamanho-- > 0)
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
