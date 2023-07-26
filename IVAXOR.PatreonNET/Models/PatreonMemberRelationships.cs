using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonMemberRelationships
    {
        /// <summary>
        /// The member's shipping address that they entered for the campaign.
        /// Requires the campaign.members.address scope.
        /// </summary>
        [JsonPropertyName("address")]
        public PatreonAddressAttributes Address { get; set; }

        /// <summary>
        /// The campaign that the membership is for.
        /// </summary>
        [JsonPropertyName("campaign")]
        public PatreonCampaignV2Attributes Campaign { get; set; }

        /// <summary>
        /// The tiers that the member is entitled to.
        /// This includes a current pledge, or payment that covers the current payment period.
        /// </summary>
        [JsonPropertyName("currently_entitled_tiers")]
        public PatreonTierAttributes[] CurrentlyEntitledTiers { get; set; }

        /// <summary>
        /// The pledge history of the member.
        /// </summary>
        [JsonPropertyName("pledge_history")]
        public PatreonPledgeEventAttributes[] PledgeHistory { get; set; }

        /// <summary>
        /// The user who is pledging to the campaign.
        /// </summary>
        [JsonPropertyName("user")]
        public PatreonUserV2Attributes User { get; set; }
    }
}
