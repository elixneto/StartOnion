using System.Security.Cryptography;
using System.Text;

namespace StartOnion.Camada.CrossCutting.Utilidades.Criptografia
{
    /// <summary>
    /// Criptografia MD5
    /// </summary>
    public static class CriptografiaMD5
    {
        /// <summary>
        /// Converte um texto em string MD5
        /// </summary>
        /// <param name="texto">String a ser criptografada</param>
        /// <param name="maiusculo">Retorno em maiúsculo?</param>
        /// <returns></returns>
        public static string ConverterTexto(string texto, bool maiusculo = false)
        {
            byte[] data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(texto));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString(maiusculo ? "X2" : "x2"));

            return sBuilder.ToString();
        }
    }
}
