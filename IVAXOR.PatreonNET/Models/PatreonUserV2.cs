using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    /// <summary>
    /// The Patreon user, which can be both patron and creator.
    /// </summary>
    public class PatreonUserV2
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("attributes")]
        public PatreonUserV2Attributes Attributes { get; set; }

        [JsonPropertyName("relationships")]
        public PatreonUserV2SocialConnections Relationships { get; set; }
    }
}
