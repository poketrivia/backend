using Marten;
using Marten.Services;

namespace PokeTrivia.Core.Database
{
    public static class DatabaseInstance
    {
        public static IDocumentStore GetStore()
        {
            return DocumentStore.For(options =>
            {
                options.Connection($"host=localhost;port=5432;database=PokeTrivia;username=poketrivia");

                options.Serializer(new JsonNetSerializer
                {
                    EnumStorage = EnumStorage.AsString
                });
            });
        }
    }
}