using IVAXOR.PatreonNET.Models.Relationships;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Webhooks
{
    public class PatreonWebhookRelationships : IPatreonRelationships
    {
        /// <summary>
        /// The campaign whose events trigger the webhook.
        /// </summary>
        [JsonPropertyName("campaign")]
        public PatreonRelationshipsSingle? Campaign { get; set; }

        /// <summary>
        /// The client which created the webhook.
        /// </summary>
        [JsonPropertyName("client")]
        public PatreonRelationshipsSingle? Client { get; set; }
    }
}
