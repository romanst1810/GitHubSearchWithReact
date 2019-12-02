using Newtonsoft.Json;

namespace Isracard.Core.Domain
{
    public class RepositoryItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("full_name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }


        protected bool Equals(RepositoryItem other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RepositoryItem) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
