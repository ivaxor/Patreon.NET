using IVAXOR.PatreonNET.Models.Goals;
using IVAXOR.PatreonNET.Models.Interfaces;
using IVAXOR.PatreonNET.Models.Tiers;
using IVAXOR.PatreonNET.Models.Users;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Campaigns
{
    public class PatreonCampaignV2Relationships : IPatreonRelationships
    {
        /// <summary>
        /// The campaign's benefits.
        /// </summary>
        [JsonPropertyName("benefits")]
        public PatreonCampaignInstallation[] Benefits { get; set; }

        [JsonPropertyName("campaign_installations")]
        public PatreonCampaignInstallation[] CampaignInstallations { get; set; }

        /// <summary>
        /// 	The campaign's categories.
        /// </summary>
        [JsonPropertyName("categories")]
        public PatreonCategoryCategory[] Categories { get; set; }

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

        /// <summary>
        /// The campaign's tiers.
        /// </summary>
        [JsonPropertyName("tiers")]
        public PatreonTierAttributes[] Tiers { get; set; }
    }
}
