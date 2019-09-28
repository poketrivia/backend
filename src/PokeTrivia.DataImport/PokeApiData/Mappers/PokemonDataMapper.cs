using System.Collections.Generic;
using System.Linq;
using PokeTrivia.DataImport.PokeApiData.Models;
using Zio;

namespace PokeTrivia.DataImport.PokeApiData.Mappers
{
    public static class PokemonDataMapper
    {
        public static List<PokemonData> GetPokemons()
        {
            var directoryEntries = ApiDataFileSystem.FileSystem.EnumerateDirectoryEntries("/pokemon");

            var files = directoryEntries
                .Select(dir => dir.EnumerateEntries().FirstOrDefault(e => e.Name == "index.json"))
                .Where(file => file != null)
                .Select(file => ApiDataFileSystem.FileSystem.ReadAllText(file.FullName));

            return ApiDataDeserializer.DeserializeData<PokemonData>(files).ToList();
        }
    }
}