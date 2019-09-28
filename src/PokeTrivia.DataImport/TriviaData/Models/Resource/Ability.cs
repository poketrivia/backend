using System.Collections.Generic;
using Marten.Schema;
using Newtonsoft.Json;
using PokeTrivia.DataImport.PokeApiData.Models;

namespace PokeTrivia.DataImport.TriviaData.Models.Resource
{
    public class Ability
    {
        [Identity]
        public string Name { get; set; }

        public List<AbilityNameData> Names { get; set; }

        public List<AbilityEffectEntryData> EffectEntries { get; set; }

        public List<AbilityFlavorTextEntryData> FlavorTextEntries { get; set; }

        public List<AbilityPokemonData> Pokemons { get; set; }

        public bool IsMainSeries { get; set; }
    }
}