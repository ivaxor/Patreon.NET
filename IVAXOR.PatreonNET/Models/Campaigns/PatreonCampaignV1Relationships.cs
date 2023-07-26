using IVAXOR.PatreonNET.Models.Goals;
using IVAXOR.PatreonNET.Models.Interfaces;
using IVAXOR.PatreonNET.Models.Rewards;
using IVAXOR.PatreonNET.Models.Users;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Campaigns
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
