using System;
using System.Security.Cryptography;
using System.Text;

namespace StartOnion.Camada.CrossCutting.Seguranca
{
    /// <summary>
    /// Gerador de salt
    /// </summary>
    public static class GeradorDeHash
    {
        /// <summary>
        /// Gera um salt
        /// </summary>
        /// <param name="tamanho">Quantidade de caracteres gerados</param>
        /// <returns></returns>
        public static byte[] GerarSalt(int tamanho)
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

        /// <summary>
        /// Gera um hash a partir de um texto e um salt
        /// </summary>
        /// <param name="textoEmBytes">Texto em bytes</param>
        /// <param name="saltEmBytes">Salt em bytes</param>
        /// <returns></returns>
        public static byte[] GerarSaltedHashSHA256(byte[] textoEmBytes, byte[] saltEmBytes)
        {
            var textoComSaltEmBytes = new byte[textoEmBytes.Length + saltEmBytes.Length];

            for (int i = 0; i < textoEmBytes.Length; i++)
                textoComSaltEmBytes[i] = textoEmBytes[i];

            for (int i = 0; i < saltEmBytes.Length; i++)
                textoComSaltEmBytes[textoEmBytes.Length + i] = saltEmBytes[i];

            return new SHA256Managed().ComputeHash(textoComSaltEmBytes);
        }
    }
}
