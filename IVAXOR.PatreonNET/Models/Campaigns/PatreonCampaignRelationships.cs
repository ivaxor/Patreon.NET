using IVAXOR.PatreonNET.Models.Relationships;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Campaigns
{
    public class PatreonCampaignRelationships : IPatreonRelationships
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

        /// <summary>
        /// The campaign's rewards.
        /// </summary>
        [JsonPropertyName("rewards")]
        public PatreonRelationshipsMulti Rewards { get; set; }
    }
}
