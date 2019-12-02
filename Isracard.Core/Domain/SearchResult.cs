using Newtonsoft.Json;

namespace Isracard.Core.Domain
{
    public class SearchResult
    {
        [JsonProperty("total_count")]
        public int Total { get; set; }


        [JsonProperty("items")]
        public RepositoryItem[] Items { get; set; }
    }
}