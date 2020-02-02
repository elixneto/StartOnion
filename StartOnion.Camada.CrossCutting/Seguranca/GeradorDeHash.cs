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
        public static byte[] GerarSaltEmBytes(int tamanho)
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
        /// Gera um Hash e um novo salt
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="tamanhoDoSalt"></param>
        /// <returns>Hash, Salt</returns>
        public static Tuple<string, string> GerarSaltedHashSHA512(string texto, int tamanhoDoSalt)
        {
            var saltEmBytes = GerarSaltEmBytes(tamanhoDoSalt);
            return GerarSHA512(texto, saltEmBytes);
        }
        /// <summary>
        /// Gera um Hash com um salt já existente
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="saltEmBytes"></param>
        /// <returns></returns>
        public static string GerarSaltedHashSHA512(string texto, byte[] saltEmBytes)
            => GerarSHA512(texto, saltEmBytes).Item1;


        private static Tuple<string, string> GerarSHA512(string texto, byte[] saltEmBytes)
        {
            var textoEmBytes = Encoding.UTF8.GetBytes(texto);
            var textoComSaltEmBytes = new byte[textoEmBytes.Length + saltEmBytes.Length];

            for (int i = 0; i < textoEmBytes.Length; i++)
                textoComSaltEmBytes[i] = textoEmBytes[i];

            for (int i = 0; i < saltEmBytes.Length; i++)
                textoComSaltEmBytes[textoEmBytes.Length + i] = saltEmBytes[i];

            return new Tuple<string, string>(Convert.ToBase64String(new SHA512Managed().ComputeHash(textoComSaltEmBytes)), Encoding.UTF8.GetString(saltEmBytes));
        }
    }
}
