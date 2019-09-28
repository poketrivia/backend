using System.Collections.Generic;
using System.Linq;
using PokeTrivia.DataImport.PokeApiData.Models;
using Zio;

namespace PokeTrivia.DataImport.PokeApiData.Mappers
{
    public static class AbilityDataMapper
    {
        public static List<AbilityData> GetAbilities()
        {
            var directoryEntries = ApiDataFileSystem.FileSystem.EnumerateDirectoryEntries("/ability");

            var files = directoryEntries
                .Select(dir => dir.EnumerateEntries().FirstOrDefault(e => e.Name == "index.json"))
                .Where(file => file != null)
                .Select(file => ApiDataFileSystem.FileSystem.ReadAllText(file.FullName));

            return ApiDataDeserializer.DeserializeData<AbilityData>(files).ToList();
        }
    }
}