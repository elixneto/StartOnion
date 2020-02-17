using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace StartOnion.CrossCutting.Utilities.Helpers
{
    /// <summary>
    /// Compress helper
    /// </summary>
    public static class CompressHelper
    {
        /// <summary>
        /// Compress a file
        /// </summary>
        /// <param name="fileInBytes">Conteúdo do arquivo em Bytes</param>
        /// <returns></returns>
        public static byte[] Compress(byte[] fileInBytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Create))
                    using (var streamDeEscrita = new BinaryWriter(zip.CreateEntry("zipEntry").Open()))
                        streamDeEscrita.Write(fileInBytes);

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Compress many files
        /// </summary>
        /// <param name="filesInBytes"></param>
        /// <returns></returns>
        public static byte[] Compress(IEnumerable<byte[]> filesInBytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Create))
                    foreach(var bytes in filesInBytes)
                        using (var streamDeEscrita = new BinaryWriter(zip.CreateEntry("zipEntry").Open()))
                            streamDeEscrita.Write(bytes);

                return memoryStream.ToArray();
            }
        }
    }
}
