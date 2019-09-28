using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokeTrivia.DataImport.Git
{
    public static class RepositoryActions
    {
        private const string RepoUrl = "https://github.com/PokeAPI/api-data";
        private const string RepoBranch = "master";

        private static string RepoZipUrl => $"{RepoUrl}/archive/{RepoBranch}.zip";

        public static async Task<Stream> GetRepositoryZipStreamAsync()
        {
            using (var client = new HttpClient())
            {
                var contents = await client.GetStreamAsync(RepoZipUrl);

                return contents;
            }
        }
    }
}