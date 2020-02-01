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
        /// <returns></returns>
        public static byte[] CompactarUm(byte[] arquivoEmBytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Create))
                    using (var streamDeEscrita = new BinaryWriter(zip.CreateEntry("zipEntry").Open()))
                        streamDeEscrita.Write(arquivoEmBytes);

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Compacta muitos arquivos
        /// </summary>
        /// <param name="arquivosEmBytes"></param>
        /// <returns></returns>
        public static byte[] CompactarMuitos(IEnumerable<byte[]> arquivosEmBytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Create))
                    foreach(var bytes in arquivosEmBytes)
                        using (var streamDeEscrita = new BinaryWriter(zip.CreateEntry("zipEntry").Open()))
                            streamDeEscrita.Write(bytes);

                return memoryStream.ToArray();
            }
        }
    }
}
