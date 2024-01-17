using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Tiers;

public class PatreonTierRelationships : IPatreonRelationships
{
    /// <summary>
    /// The benefits attached to the tier, which are used for generating deliverables.
    /// </summary>
    [JsonPropertyName("benefits")]
    public PatreonRelationshipsMulti? Benefits { get; set; }

    /// <summary>
    /// The campaign the tier belongs to.
    /// </summary>
    [JsonPropertyName("campaign")]
    public PatreonRelationshipsSingle? Campaign { get; set; }

    /// <summary>
    /// The image file associated with the tier.
    /// </summary>
    [JsonPropertyName("tier_image")]
    public PatreonRelationshipsSingle? TierImage { get; set; }
}
