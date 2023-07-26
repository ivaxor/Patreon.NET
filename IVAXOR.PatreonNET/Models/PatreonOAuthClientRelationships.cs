using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonOAuthClientRelationships
    {
        /// <summary>
        /// (Alpha)
        /// The apps that this client controls.
        /// </summary>
        [JsonPropertyName("apps")]
        public PatreonPlatformApp[] Apps { get; set; }

        /// <summary>
        /// The campaign of the user who created the OAuth Client.
        /// </summary>
        [JsonPropertyName("campaign")]
        public PatreonCampaignV2Attributes Campaign { get; set; }

        /// <summary>
        /// The token of the user who created the client.
        /// </summary>
        [JsonPropertyName("creator_token")]
        public PatreonOAuthToken CreatorToken { get; set; }

        /// <summary>
        /// The user who created the OAuth Client.
        /// </summary>
        [JsonPropertyName("user")]
        public PatreonUserV2Attributes User { get; set; }
    }
}
