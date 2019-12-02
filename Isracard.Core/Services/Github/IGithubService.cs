using System.Collections.Generic;
using System.Text;
using Isarcard.Core.Abstraction;
using Isracard.Core.Domain;

namespace Isracard.Core.Services.Github
{
    public interface IGithubService : ISearchService<SearchResult, RepositorySearchSpecification>
    {
    }
}
