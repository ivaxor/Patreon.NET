using IVAXOR.PatreonNET.Models.Campaigns;
using IVAXOR.PatreonNET.Models.Interfaces;
using IVAXOR.PatreonNET.Models.OAuths;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Webhooks
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
        public PatreonOAuthClientAttributes Client { get; set; }
    }
}
