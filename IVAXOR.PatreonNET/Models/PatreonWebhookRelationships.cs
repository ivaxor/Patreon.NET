using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonWebhookRelationships : IPatreonRelationships
    {
        /// <summary>
        /// The campaign whose events trigger the webhook.
        /// </summary>
        [JsonPropertyName("campaign")]
        public PatreonCampaignV2Attributes Campaign { get; set; }

        /// <summary>
        /// The client which created the webhook.
        /// </summary>
        [JsonPropertyName("client")]
        public PatreobOAuthClientAttributes Client { get; set; }
    }
}
