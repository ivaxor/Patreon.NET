using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonClientTokens
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("scope")]
        public string Scopes { get; set; }
    }
}
