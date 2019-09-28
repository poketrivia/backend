using System.Collections.Generic;
using System.Linq;
using PokeTrivia.DataImport.PokeApiData.Models;
using Zio;

namespace PokeTrivia.DataImport.PokeApiData.Mappers
{
    public static class MoveDataMapper
    {
        public static List<MoveData> GetMoves()
        {
            var directoryEntries = ApiDataFileSystem.FileSystem.EnumerateDirectoryEntries("/move");

            var files = directoryEntries
                .Select(dir => dir.EnumerateEntries().FirstOrDefault(e => e.Name == "index.json"))
                .Where(file => file != null)
                .Select(file => ApiDataFileSystem.FileSystem.ReadAllText(file.FullName));

            return ApiDataDeserializer.DeserializeData<MoveData>(files).ToList();
        }
    }
}