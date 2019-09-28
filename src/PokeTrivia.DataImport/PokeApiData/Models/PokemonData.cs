using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokeTrivia.DataImport.PokeApiData.Models
{
    public class PokemonData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("species.name")]
        public string SpeciesName { get; set; }

        [JsonProperty("base_experience")]
        public int BaseExperience { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("types")]
        public List<PokemonTypeData> Types { get; set; }

        [JsonProperty("stats")]
        public List<PokemonStatData> Stats { get; set; }

        [JsonProperty("sprites")]
        public PokemonSpritesData Sprites { get; set; }
    }

    public class PokemonTypeData
    {
        [JsonProperty("type.name")]
        public string TypeName { get; set; }

        [JsonProperty("slot")]
        public int Slot { get; set; }
    }

    public class PokemonStatData
    {
        [JsonProperty("stat.name")]
        public string StatName { get; set; }

        [JsonProperty("base_stat")]
        public int BaseStat { get; set; }

        [JsonProperty("effort")]
        public int EffortValue { get; set; }
    }

    public class PokemonSpritesData
    {
        [JsonProperty("back_default")]
        public string BackDefault { get; set; }

        [JsonProperty("back_female")]
        public string BackFemale { get; set; }

        [JsonProperty("back_shiny")]
        public string BackDefaultShiny { get; set; }

        [JsonProperty("back_shiny_female")]
        public string BackFemaleShiny { get; set; }

        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }

        [JsonProperty("front_female")]
        public string FrontFemale { get; set; }

        [JsonProperty("front_shiny")]
        public string FrontDefaultShiny { get; set; }

        [JsonProperty("front_shiny_female")]
        public string FrontFemaleShiny { get; set; }
    }
}