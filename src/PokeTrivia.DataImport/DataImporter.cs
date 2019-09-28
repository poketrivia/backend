using System;
using System.Linq;
using PokeTrivia.DataImport.Git;
using PokeTrivia.DataImport.PokeApiData;
using PokeTrivia.DataImport.PokeApiData.Mappers;

namespace PokeTrivia.DataImport
{
    static class DataImporter
    {
        static void Main(string[] args)
        {
            var repoZipStream = RepositoryActions.GetRepositoryZipStreamAsync().Result;

            using (repoZipStream)
            {
                ApiDataFileSystem.LoadFromZip(repoZipStream);
            }

            var moves = MoveDataMapper.GetMoves();
            
        }
    }
}