using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Users
{
    public class PatreonUserSocialConnection
    {
        [JsonRequired]
        [JsonPropertyName("scopes")]
        public string[] Scopes { get; set; }

        [JsonRequired]
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonRequired]
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
