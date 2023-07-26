﻿using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonTierRelationships : IPatreonRelationships
    {
        /// <summary>
        /// The benefits attached to the tier, which are used for generating deliverables.
        /// </summary>
        [JsonPropertyName("benefits")]
        public PatreonBenefitAttributes[] Benefits { get; set; }

        /// <summary>
        /// The campaign the tier belongs to.
        /// </summary>
        [JsonPropertyName("campaign")]
        public PatreonCampaignV2Attributes Campaign { get; set; }

        /// <summary>
        /// The image file associated with the tier.
        /// </summary>
        [JsonPropertyName("tier_image")]
        public PatreonMediaAttributes TierImage { get; set; }
    }
}
