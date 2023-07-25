using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonUserV2SocialConnection
    {
        [JsonPropertyName("scopes")]
        public string[] Scopes { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
