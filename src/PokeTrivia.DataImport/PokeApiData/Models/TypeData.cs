using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokeTrivia.DataImport.PokeApiData.Models
{
    public class TypeData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("names")]
        public List<TypeNameData> Names { get; set; }

        [JsonProperty("generation.name")]
        public string GenerationIntroduced { get; set; }

        [JsonProperty("damage_relations")]
        public TypeDamageRelationData DamageRelations { get; set; }
    }

    public class TypeNameData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("language.name")]
        public string Language { get; set; }
    }

    public class TypeDamageRelationData
    {
        [JsonProperty("double_damage_from[*].name")]
        public List<string> DoubleDamageFrom { get; set; }

        [JsonProperty("double_damage_to[*].name")]
        public List<string> DoubleDamageTo { get; set; }

        [JsonProperty("half_damage_from[*].name")]
        public List<string> HalfDamageFrom { get; set; }

        [JsonProperty("half_damage_to[*].name")]
        public List<string> HalfDamageTo { get; set; }

        [JsonProperty("no_damage_from[*].name")]
        public List<string> NoDamageFrom { get; set; }

        [JsonProperty("no_damage_to[*].name")]
        public List<string> NoDamageTo { get; set; }
    }
}