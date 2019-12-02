using System;
using System.Threading.Tasks;
using Isracard.Core.Domain;
using Isracard.Core.Services.Bookmark;
using Isracard.Core.Services.Github;
using Xunit;

namespace Isracard.Tests
{
    public class ServicesTest
    {
        [Fact]
        public async Task GithubSearchServiceTest()
        {
            IGithubService service = new GithubService();
            var spec= new RepositorySearchSpecification()
            {
                Text = "Isrcard"
            };
            var result = await service.SearchAsync(spec);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task BookmarkServiceTest()
        {
            IBookmarkService service = new BookmarkService();
            var item = new BookmarkContext()
            {
               UserId = Guid.NewGuid().ToString(),
               Item = new RepositoryItem()
            };

            await service.SaveAsync(item);

            var result = await service.FetchAsync(item.UserId);


            Assert.NotNull(result);

            Assert.True(result.Length == 1);
        }
    }
}
