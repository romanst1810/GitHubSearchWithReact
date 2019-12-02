using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Tasks;
using Isracard.Core.Domain;

namespace Isracard.Core.Services.Bookmark
{
    public interface IBookmarkService
    {
        Task SaveAsync(BookmarkContext item);

        Task<RepositoryItem[]> FetchAsync(string userId);
    }

    public class BookmarkContext
    {
        public string UserId { get; set; }

        public RepositoryItem Item{ get; set; }
    }
}
