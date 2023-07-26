using IVAXOR.PatreonNET.Models.Campaigns;
using IVAXOR.PatreonNET.Models.Interfaces;
using IVAXOR.PatreonNET.Models.Users;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Addresses
{
    public class PatreonAddressRelationships : IPatreonRelationships
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
