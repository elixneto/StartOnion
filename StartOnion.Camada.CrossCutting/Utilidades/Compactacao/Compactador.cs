using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace StartOnion.Camada.CrossCutting.Utilidades.Compactacao
{
    /// <summary>
    /// Compressor de arquivos
    /// </summary>
    public static class Compactador
    {
        /// <summary>
        /// Compacta 1 arquivo
        /// </summary>
        /// <param name="arquivoEmBytes">Conteúdo do arquivo em Bytes</param>
        /// <param name="caminhoDeSaidaZip"></param>
        /// <returns></returns>
        public static byte[] CompactarUm(byte[] arquivoEmBytes, string caminhoDeSaidaZip)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Create))
                    using (var streamDeEscrita = new BinaryWriter(zip.CreateEntry(caminhoDeSaidaZip).Open()))
                        streamDeEscrita.Write(arquivoEmBytes);

                return memoryStream.ToArray();
            }
        }
        
        // TODO: testar esse método
        public static byte[] CompactarMuitos(IEnumerable<byte[]> arquivosEmBytes, string caminhoDeSaidaZip)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Create))
                    foreach(var bytes in arquivosEmBytes)
                        using (var streamDeEscrita = new BinaryWriter(zip.CreateEntry(caminhoDeSaidaZip).Open()))
                            streamDeEscrita.Write(bytes);

                return memoryStream.ToArray();
            }
        }
    }
}
