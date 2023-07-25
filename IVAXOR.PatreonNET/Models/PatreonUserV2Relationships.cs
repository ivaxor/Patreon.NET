using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonUserV2Relationships : IPatreonRelationships
    {
        [JsonPropertyName("campaign")]
        public PatreonCampaignV2 Campaign { get; set; }

        [JsonPropertyName("memberships")]
        public PatreonMember[] Memberships { get; set; }
    }
}
