using System.IO;
using System.IO.Compression;
using System.Linq;
using Zio;
using Zio.FileSystems;

namespace PokeTrivia.DataImport.PokeApiData
{
    public static class ApiDataFileSystem
    {
        public static MemoryFileSystem FileSystem { get; private set; }

        public static void LoadFromZip(Stream zipStream)
        {
            Reset();

            using (var zip = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                const string zipDataFilePrefix = "api-data-master/data/api/v2";

                var entriesToLoad = zip.Entries
                    // Get only the data files
                    .Where(e => e.FullName.StartsWith(zipDataFilePrefix));

                foreach (var entry in entriesToLoad)
                {
                    var fsPath = entry.FullName.Replace(zipDataFilePrefix, "");

                    // It's the root, ignore
                    if (fsPath == "/")
                    {
                        continue;
                    }

                    // It's a directory
                    if (fsPath.EndsWith("/"))
                    {
                        FileSystem.CreateDirectory(fsPath);
                        continue;
                    }

                    // It's a file
                    using (var entryStream = entry.Open())
                    using (var memoryStream = new MemoryStream())
                    {
                        entryStream.CopyTo(memoryStream);

                        FileSystem.WriteAllBytes(fsPath, memoryStream.ToArray());
                    }
                }
            }
        }

        public static void Reset()
        {
            if (FileSystem != null)
            {
                FileSystem.DeleteDirectory(UPath.Root, true);
                FileSystem.Dispose();
            }

            FileSystem = new MemoryFileSystem();
        }
    }
}