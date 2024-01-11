using IVAXOR.PatreonNET.Models.Relationships;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PledgeEventsV2;

public class PatreonPledgeEventV2Relationships : IPatreonRelationships
{
    /// <summary>
    /// The campaign being pledged to.
    /// </summary>
    [JsonPropertyName("campaign")]
    public PatreonRelationshipsSingle? Campaign { get; set; }

    /// <summary>
    /// The pledging user.
    /// </summary>
    [JsonPropertyName("patron")]
    public PatreonRelationshipsSingle? Patron { get; set; }

    /// <summary>
    /// The tier associated with this pledge event.
    /// </summary>
    [JsonPropertyName("tier")]
    public PatreonRelationshipsSingle? Tier { get; set; }
}