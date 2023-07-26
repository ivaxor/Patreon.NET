using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonDeliverableRelationships
    {
        /// <summary>
        /// The Benefit the Deliverables were generated for.
        /// </summary>
        [JsonPropertyName("benefit")]
        public PatreonBenefitAttributes Benefit { get; set; }

        /// <summary>
        /// The Campaign the Deliverables were generated for.
        /// </summary>
        [JsonPropertyName("campaign")]
        public PatreonCampaignV2Attributes campaign { get; set; }

        /// <summary>
        /// The member who has been granted the deliverable.
        /// </summary>
        [JsonPropertyName("member")]
        public PatreonMemberAttributes member { get; set; }

        /// <summary>
        /// The user who has been granted the deliverable.
        /// This user is the same as the member user.
        /// </summary>
        [JsonPropertyName("user")]
        public PatreonUserV2Attributes user { get; set; }
    }
}
