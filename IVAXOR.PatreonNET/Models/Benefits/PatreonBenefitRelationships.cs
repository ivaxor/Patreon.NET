using IVAXOR.PatreonNET.Models.Relationships;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Benefits
{
    public class PatreonBenefitRelationships
    {
        [JsonRequired]
        [JsonPropertyName("campaign")]
        public PatreonRelationshipsSingle Campaign { get; set; }

        [JsonRequired]
        [JsonPropertyName("campaign_installation")]
        public PatreonRelationshipsSingle CampaignInstallation { get; set; }

        [JsonRequired]
        [JsonPropertyName("deliverables")]
        public PatreonRelationshipsMulti Deliverables { get; set; }

        [JsonRequired]
        [JsonPropertyName("tiers")]
        public PatreonRelationshipsMulti Tiers { get; set; }
    }
}