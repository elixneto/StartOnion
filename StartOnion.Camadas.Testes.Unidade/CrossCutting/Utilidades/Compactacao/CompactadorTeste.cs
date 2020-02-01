using StartOnion.Camada.CrossCutting.Utilidades.Compactacao;
using System.IO;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Utilidades.Compactacao
{
    public class CompactadorTeste
    {
        private readonly string _caminhoDoArquivoParaCompactar = @"C:\Users\Élix Neto\Documents\Rz3\GIT\StartOnion\src\StartOnion.Camadas.Testes.Unidade\CrossCutting\Utilidades\Compactacao\ArquivoParaCompactar.txt";

        [Fact]
        public void DeveCompactarUmArrayDeBytes()
        {
            byte[] bytesDoArquivoParaCompactar = File.ReadAllBytes(_caminhoDoArquivoParaCompactar);
            var tamanhoOriginal = bytesDoArquivoParaCompactar.Length;

            var tamanhoCompactado = Compactador.CompactarUm(bytesDoArquivoParaCompactar).Length;

            Assert.Equal(15988, tamanhoOriginal);
            Assert.Equal(6893, tamanhoCompactado);
        }
    }
}
