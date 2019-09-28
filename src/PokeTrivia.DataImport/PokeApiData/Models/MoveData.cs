using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokeTrivia.DataImport.PokeApiData.Models
{
    public class MoveData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("names")]
        public List<MoveNameData> Names { get; set; }

        [JsonProperty("type.name")]
        public string TypeName { get; set; }

        [JsonProperty("target.name")]
        public string TargetName { get; set; }

        [JsonProperty("accuracy")]
        public int Accuracy { get; set; }

        [JsonProperty("power")]
        public int Power { get; set; }

        [JsonProperty("pp")]
        public int PP { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("damage_class.name")]
        public string DamageClass { get; set; }

        [JsonProperty("generation.name")]
        public string GenerationIntroduced { get; set; }

        [JsonProperty("meta")]
        public MoveMetaData Meta { get; set; }

        [JsonProperty("stat_changes")]
        public List<MoveStatChangeData> StatChanges { get; set; }

        [JsonProperty("effect_chance")]
        public int EffectChance { get; set; }

        [JsonProperty("effect_entries")]
        public List<MoveEffectEntryData> EffectEntries { get; set; }

        [JsonProperty("flavor_text_entries")]
        public List<MoveFlavorTextEntryData> FlavorTextEntries { get; set; }
    }

    public class MoveNameData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("language.name")]
        public string Language { get; set; }
    }

    public class MoveEffectEntryData
    {
        [JsonProperty("effect")]
        public string Effect { get; set; }

        [JsonProperty("short_effect")]
        public string ShortEffect { get; set; }

        [JsonProperty("language.name")]
        public string Language { get; set; }
    }

    public class MoveFlavorTextEntryData
    {
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        [JsonProperty("language.name")]
        public string Language { get; set; }

        [JsonProperty("version_group.name")]
        public string VersionGroup { get; set; }
    }

    public class MoveMetaData
    {
        [JsonProperty("ailment.name")]
        public string AilmentName { get; set; }

        [JsonProperty("ailment_chance")]
        public int AilmentChance { get; set; }

        [JsonProperty("crit_rate")]
        public int CritChance { get; set; }

        [JsonProperty("flinch_chance")]
        public int FlinchChance { get; set; }

        [JsonProperty("stat_chance")]
        public int StatChance { get; set; }

        [JsonProperty("drain")]
        public int Drain { get; set; }

        [JsonProperty("healing")]
        public int Healing { get; set; }

        [JsonProperty("max_hits")]
        public int MaxHits { get; set; }

        [JsonProperty("min_hits")]
        public int MinHits { get; set; }

        [JsonProperty("max_turns")]
        public int MaxTurns { get; set; }

        [JsonProperty("min_turns")]
        public int MinTurns { get; set; }
    }

    public class MoveStatChangeData
    {
        [JsonProperty("change")]
        public int Change { get; set; }

        [JsonProperty("stat.name")]
        public string StatName { get; set; }
    }
}