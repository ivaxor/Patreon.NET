using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonAddressRelationships
    {
        /// <summary>
        /// The campaigns that have access to the address.
        /// </summary>
        [JsonPropertyName("campaigns")]
        public PatreonCampaignV2Attributes Campaigns { get; set; }

        /// <summary>
        /// The user this address belongs to.
        /// </summary>
        [JsonPropertyName("user")]
        public PatreonUserV2Attributes User { get; set; }
    }
}
