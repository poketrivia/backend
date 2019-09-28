using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokeTrivia.DataImport.PokeApiData.Models
{
    public class AbilityData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("names")]
        public List<AbilityNameData> Names { get; set; }

        [JsonProperty("effect_entries")]
        public List<AbilityEffectEntryData> EffectEntries { get; set; }

        [JsonProperty("flavor_text_entries")]
        public List<AbilityFlavorTextEntryData> FlavorTextEntries { get; set; }

        [JsonProperty("pokemon")]
        public List<AbilityPokemonData> Pokemons { get; set; }

        [JsonProperty("is_main_series")]
        public bool IsMainSeries { get; set; }
    }

    public class AbilityNameData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("language.name")]
        public string Language { get; set; }
    }

    public class AbilityEffectEntryData
    {
        [JsonProperty("effect")]
        public string Effect { get; set; }

        [JsonProperty("short_effect")]
        public string ShortEffect { get; set; }

        [JsonProperty("language.name")]
        public string Language { get; set; }
    }

    public class AbilityFlavorTextEntryData
    {
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        [JsonProperty("language.name")]
        public string Language { get; set; }

        [JsonProperty("version_group.name")]
        public string VersionGroup { get; set; }
    }

    public class AbilityPokemonData
    {
        [JsonProperty("pokemon.name")]
        public string Name { get; set; }

        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonProperty("slot")]
        public int Slot { get; set; }
    }
}