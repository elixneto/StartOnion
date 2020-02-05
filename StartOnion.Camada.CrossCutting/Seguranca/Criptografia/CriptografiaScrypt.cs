using Scrypt;

namespace StartOnion.Camada.CrossCutting.Seguranca.Criptografia
{
    /// <summary>
    /// Criptografia Scrypt
    /// </summary>
    public static class CriptografiaScrypt
    {
        private const int BLOCO = 8;
        private const int THREADS = 8;
        private const int CUSTO = 16384;

        /// <summary>
        /// Retorna o hash de criptografia
        /// </summary>
        /// <param name="senha">Senha para ser criptografada</param>
        /// <param name="salt">Salt</param>
        /// <returns></returns>
        public static string CriptografarSenha(string senha, string salt)
            => new ScryptEncoder(CUSTO, BLOCO, THREADS).Encode(AplicarPadraoNoTexto(senha, salt));
        /// <summary>
        /// Retorna o hash de criptografia
        /// </summary>
        /// <param name="texto">Texto para ser criptografado</param>
        /// <returns></returns>
        public static string CriptografarTexto(string texto)
            => new ScryptEncoder(CUSTO, BLOCO, THREADS).Encode(texto);

        /// <summary>
        /// Retorna <code>true</code> ou <code>false</code> se a senha é o hash
        /// </summary>
        /// <param name="senha">Senha em plain text a ser verificada</param>
        /// <param name="salt">Salt da senha</param>
        /// <param name="hash">Hash a ser verificado</param>
        /// <returns></returns>
        public static bool ValidarSenhaComHash(string senha, string salt, string hash)
            => new ScryptEncoder(CUSTO, BLOCO, THREADS).Compare(AplicarPadraoNoTexto(senha, salt), hash);
        /// <summary>
        /// Retorna <code>true</code> ou <code>false</code> se o texto é o hash
        /// </summary>
        /// <param name="texto">Texto em plain text a ser verificado</param>
        /// <param name="hash">Hash a ser verificado</param>
        /// <returns></returns>
        public static bool ValidarTextoComHash(string texto, string hash)
            => new ScryptEncoder(CUSTO, BLOCO, THREADS).Compare(texto, hash);

        private static string AplicarPadraoNoTexto(string texto, string salt)
            => $"0n10n.{texto}..{salt}.S4LT";
    }
}
