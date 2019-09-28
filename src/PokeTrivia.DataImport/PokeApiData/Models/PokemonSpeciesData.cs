using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokeTrivia.DataImport.PokeApiData.Models
{
    public class PokemonSpeciesData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("names")]
        public List<PokemonSpeciesNameData> Names { get; set; }

        [JsonProperty("base_happiness")]
        public int BaseHappiness { get; set; }

        [JsonProperty("capture_rate")]
        public int CaptureRate { get; set; }

        [JsonProperty("color.name")]
        public string Color { get; set; }

        [JsonProperty("generation.name")]
        public string Generation { get; set; }

        [JsonProperty("gender_rate")]
        public double GenderRate { get; set; }

        [JsonProperty("has_gender_differences")]
        public bool HasGenderDifferences { get; set; }

        [JsonProperty("growth_rate.name")]
        public string GrowthRate { get; set; }

        [JsonProperty("habitat.name")]
        public string Habitat { get; set; }

        [JsonProperty("hatch_counter")]
        public int HatchCounter { get; set; }

        [JsonProperty("is_baby")]
        public bool IsBaby { get; set; }

        [JsonProperty("flavor_text_entries")]
        public List<PokemonSpeciesFlavorTextEntryData> FlavorTextEntries { get; set; }

        [JsonProperty("genera")]
        public List<PokemonSpeciesGeneraData> Genera { get; set; }

        [JsonProperty("varieties")]
        public List<PokemonSpeciesVarietyData> Varieties { get; set; }
    }

    public class PokemonSpeciesNameData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("language.name")]
        public string Language { get; set; }
    }

    public class PokemonSpeciesFlavorTextEntryData
    {
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        [JsonProperty("language.name")]
        public string Language { get; set; }

        [JsonProperty("version.name")]
        public string Version { get; set; }
    }

    public class PokemonSpeciesGeneraData
    {
        [JsonProperty("genus")]
        public string Genus { get; set; }

        [JsonProperty("language.name")]
        public string Language { get; set; }
    }

    public class PokemonSpeciesVarietyData
    {
        [JsonProperty("pokemon.name")]
        public string Pokemon { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }
    }
}