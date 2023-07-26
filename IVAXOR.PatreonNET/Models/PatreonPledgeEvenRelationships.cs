using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonPledgeEvenRelationships : IPatreonRelationships
    {
        /// <summary>
        /// The campaign being pledged to.
        /// </summary>
        [JsonPropertyName("campaign")]
        public PatreonCampaignV2Attributes Campaign { get; set; }

        /// <summary>
        /// The pledging user.
        /// </summary>
        [JsonPropertyName("patron")]
        public PatreonUserV2Attributes Patron { get; set; }

        /// <summary>
        /// The tier associated with this pledge event.
        /// </summary>
        [JsonPropertyName("tier")]
        public PatreonTierAttributes Tier { get; set; }
    }
}