using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PokeTrivia.DataImport.JsonHelpers;

namespace PokeTrivia.DataImport.PokeApiData
{
    public static class ApiDataDeserializer
    {
        public static TData DeserializeData<TData>(string jsonData)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new JsonPathConverter());

            return JsonConvert.DeserializeObject<TData>(jsonData, settings);
        }

        public static IEnumerable<TData> DeserializeData<TData>(IEnumerable<string> jsonData)
        {
            return jsonData.Select(d => DeserializeData<TData>(d));
        }
    }
}