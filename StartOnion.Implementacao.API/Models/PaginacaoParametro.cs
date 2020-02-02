namespace StartOnion.Implementacao.API.Models
{
    /// <summary>
    /// Paginação
    /// </summary>
    public sealed class PaginacaoParametro
    {
        private uint _quantidadePorPagina = 100;

        /// <summary>
        /// Número da página
        /// </summary>
        public uint Pagina { get; set; }
        /// <summary>
        /// Quantidade de registros por página (máximo 100)
        /// </summary>
        public uint QuantidadePorPagina { get => _quantidadePorPagina; set { if (value > 100) _quantidadePorPagina = 100; } }
    }
}
