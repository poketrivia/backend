using System.Collections.Generic;
using Marten.Schema;

namespace PokeTrivia.DataImport.TriviaData.Models.Resource
{
    public class Type
    {
        [Identity]
        public string Name { get; set; }

        public Dictionary<string, string> Names { get; set; }

        public string GenerationIntroduced { get; set; }

        public TypeDamageRelations DamageRelations { get; set; }
    }

    public class TypeDamageRelations
    {
        [ForeignKey(typeof(List<Type>))]
        public List<string> DoubleDamageFrom { get; set; }

        [ForeignKey(typeof(Type))]
        public List<string> DoubleDamageTo { get; set; }

        [ForeignKey(typeof(Type))]
        public List<string> HalfDamageFrom { get; set; }

        [ForeignKey(typeof(Type))]
        public List<string> HalfDamageTo { get; set; }

        [ForeignKey(typeof(Type))]
        public List<string> NoDamageFrom { get; set; }

        [ForeignKey(typeof(Type))]
        public List<string> NoDamageTo { get; set; }
    }
}