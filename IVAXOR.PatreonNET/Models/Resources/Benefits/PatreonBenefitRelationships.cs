using IVAXOR.PatreonNET.Models.Relationships;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Benefits;

public class PatreonBenefitRelationships
{
    [JsonPropertyName("campaign")]
    public PatreonRelationshipsSingle? Campaign { get; set; }

    [JsonPropertyName("campaign_installation")]
    public PatreonRelationshipsSingle? CampaignInstallation { get; set; }

    [JsonPropertyName("deliverables")]
    public PatreonRelationshipsMulti? Deliverables { get; set; }

    [JsonPropertyName("tiers")]
    public PatreonRelationshipsMulti? Tiers { get; set; }
}