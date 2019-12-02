using Newtonsoft.Json;

namespace Isracard.Core.Domain
{
    public class Owner
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}