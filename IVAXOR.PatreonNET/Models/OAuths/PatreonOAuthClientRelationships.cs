using IVAXOR.PatreonNET.Models.Interfaces;
using IVAXOR.PatreonNET.Models.Relationships;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.OAuths
{
    public class PatreonOAuthClientRelationships : IPatreonRelationships
    {
        /// <summary>
        /// (Alpha)
        /// The apps that this client controls.
        /// </summary>
        [JsonPropertyName("apps")]
        public PatreonRelationshipsMulti Apps { get; set; }

        /// <summary>
        /// The campaign of the user who created the OAuth Client.
        /// </summary>
        [JsonPropertyName("campaign")]
        public PatreonRelationshipsSingle Campaign { get; set; }

        /// <summary>
        /// The token of the user who created the client.
        /// </summary>
        [JsonPropertyName("creator_token")]
        public PatreonRelationshipsSingle CreatorToken { get; set; }

        /// <summary>
        /// The user who created the OAuth Client.
        /// </summary>
        [JsonPropertyName("user")]
        public PatreonRelationshipsSingle User { get; set; }
    }
}
