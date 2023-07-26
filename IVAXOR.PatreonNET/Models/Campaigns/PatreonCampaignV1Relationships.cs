using IVAXOR.PatreonNET.Models.Interfaces;
using IVAXOR.PatreonNET.Models.Relationships;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Campaigns
{
    public class PatreonCampaignV1Relationships : IPatreonRelationships
    {
        /// <summary>
        /// The campaign owner.
        /// </summary>
        [JsonPropertyName("creator")]
        public PatreonRelationshipsSingle Creator { get; set; }

        /// <summary>
        /// The campaign's goals.
        /// </summary>
        [JsonPropertyName("goals")]
        public PatreonRelationshipsMulti Goals { get; set; }

        [JsonPropertyName("rewards")]
        public PatreonRelationshipsMulti Rewards { get; set; }
    }
}
