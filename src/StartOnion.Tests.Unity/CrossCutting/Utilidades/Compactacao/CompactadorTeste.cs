using StartOnion.CrossCutting.Utilities.Helpers;
using System.IO;
using Xunit;

namespace StartOnion.Camadas.Testes.Unidade.CrossCutting.Utilidades.Compactacao
{
    public class CompactadorTeste
    {
        private readonly string _caminhoDoArquivoParaCompactar = @"C:\GIT\StartOnion\src\StartOnion.Tests.Unity\CrossCutting\Utilidades\Compactacao\ArquivoParaCompactar.txt";


        [Fact(Skip ="TODO: Resolver o problema do caminho do arquivo para rodar nas pipelines")]
        public void DeveCompactarUmArrayDeBytes()
        {
            byte[] bytesDoArquivoParaCompactar = File.ReadAllBytes(_caminhoDoArquivoParaCompactar);
            var tamanhoOriginal = bytesDoArquivoParaCompactar.Length;

            var tamanhoCompactado = CompressHelper.Compress(bytesDoArquivoParaCompactar).Length;

            Assert.Equal(15988, tamanhoOriginal);
            Assert.Equal(6893, tamanhoCompactado);
        }
    }
}
