using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Isracard.Core.Domain;

namespace Isracard.Core.Services.Bookmark
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IDictionary<string, HashSet<RepositoryItem>> _memoryRepository = 
            new System.Collections.Concurrent.ConcurrentDictionary<string, HashSet<RepositoryItem>>();

        public async Task SaveAsync(BookmarkContext context)
        {
            var items = GetByUserId(context.UserId);

            items.Add(context.Item);

            await Task.CompletedTask;
        }

        public async Task<RepositoryItem[]> FetchAsync(string userId)
        {
            var items = GetByUserId(userId);

            return  await Task.FromResult(items.ToArray());
        }


        private HashSet<RepositoryItem> GetByUserId(string userId)
        {

            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (!_memoryRepository.ContainsKey(userId))
            {
                _memoryRepository[userId] = new HashSet<RepositoryItem>();
            }

            return _memoryRepository[userId];

        }
    }
}