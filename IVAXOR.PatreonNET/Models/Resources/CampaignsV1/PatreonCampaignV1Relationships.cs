using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.CampaignsV1;

public class PatreonCampaignV1Relationships : IPatreonRelationships
{
    /// <summary>
    /// The campaign owner.
    /// </summary>
    [JsonPropertyName("creator")]
    public PatreonRelationshipsSingle? Creator { get; set; }

    /// <summary>
    /// The campaign's goals.
    /// </summary>
    [JsonPropertyName("goals")]
    public PatreonRelationshipsMulti? Goals { get; set; }

    [JsonPropertyName("pledges")]
    public PatreonRelationshipsMulti? Pledges { get; set; }

    /// <summary>
    /// The campaign's rewards.
    /// </summary>
    [JsonPropertyName("rewards")]
    public PatreonRelationshipsMulti? Rewards { get; set; }
}
