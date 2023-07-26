using IVAXOR.PatreonNET.Models.Campaigns;
using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Goals
{
    public class PatreonGoalRelationships : IPatreonRelationships
    {
        /// <summary>
        /// The campaign trying to reach the goal.
        /// </summary>
        [JsonPropertyName("campaign")]
        public PatreonCampaignV2Attributes Campaign { get; set; }
    }
}