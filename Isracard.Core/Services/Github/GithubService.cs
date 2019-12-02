using System;
using System.Threading.Tasks;
using Isracard.Core.Domain;
using Refit;

namespace Isracard.Core.Services.Github
{
    public class GithubService : IGithubService

    {
        private readonly string apiUrl = "https://api.github.com";
        private IGitHubApi apiProxy;

        public GithubService()
        {
            this.apiProxy = RestService.For<IGitHubApi>(apiUrl);
        }

        public async Task<SearchResult> SearchAsync(RepositorySearchSpecification spec)
        {
            spec = spec ?? throw new ArgumentNullException(nameof(spec));

            return await apiProxy.SearchAsync(spec.Text);
        }
    }
}