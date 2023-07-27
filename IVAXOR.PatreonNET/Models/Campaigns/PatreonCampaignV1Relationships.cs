using IVAXOR.PatreonNET.Models.Relationships;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Campaigns
{
    public class PatreonCampaignV1Relationships : IPatreonRelationships
    {
        /// <summary>
        /// The campaign owner.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("creator")]
        public PatreonRelationshipsSingle Creator { get; set; }

        /// <summary>
        /// The campaign's goals.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("goals")]
        public PatreonRelationshipsMulti Goals { get; set; }

        [JsonRequired]
        [JsonPropertyName("rewards")]
        public PatreonRelationshipsMulti Rewards { get; set; }
    }
}
