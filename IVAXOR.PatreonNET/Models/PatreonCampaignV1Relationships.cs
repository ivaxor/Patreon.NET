using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonCampaignV1Relationships : IPatreonRelationships
    {
        /// <summary>
        /// The campaign owner.
        /// </summary>
        [JsonPropertyName("creator")]
        public PatreonUserV2Attributes Creator { get; set; }

        /// <summary>
        /// The campaign's goals.
        /// </summary>
        [JsonPropertyName("goals")]
        public PatreonGoalAttributes Goals { get; set; }

        [JsonPropertyName("rewards")]
        public PatreonRewards[] Rewards { get; set; }
    }
}
