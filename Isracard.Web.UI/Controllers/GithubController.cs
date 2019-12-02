using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Isracard.Core.Domain;
using Isracard.Core.Services.Github;
using Microsoft.AspNetCore.Mvc;

namespace Isracard.Web.UI.Controllers
{

    [Route("api/[controller]")]
    public class GithubController : Controller
    {
        private IGithubService githubService;

        public GithubController(IGithubService service)
        {
            this.githubService = service;
        }

        // GET: api/Bookmark
        [HttpGet("search/{text}")]
        public async Task<SearchResult> Get(string text)
        {
            var spec = new RepositorySearchSpecification()
            {
                Text = text
            };

            return await this.githubService.SearchAsync(spec);
        }
    }
}
