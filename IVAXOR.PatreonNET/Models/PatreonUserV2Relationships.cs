using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonUserV2Relationships : IPatreonRelationships
    {
        [JsonPropertyName("campaign")]
        public PatreonCampaignV2Attributes Campaign { get; set; }

        [JsonPropertyName("memberships")]
        public PatreonMemberAttributes[] Memberships { get; set; }
    }
}
