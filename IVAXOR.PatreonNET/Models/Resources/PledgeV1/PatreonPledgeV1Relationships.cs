using IVAXOR.PatreonNET.Models.Response.Relationships;
using IVAXOR.PatreonNET.Models.Response.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PledgeV1;

public class PatreonPledgeV1Relationships : IPatreonRelationships
{
    [JsonPropertyName("patron")]
    public PatreonRelationshipsSingle? Patron { get; set; }

    [JsonPropertyName("reward")]
    public PatreonRelationshipsSingle? Reward { get; set; }

    [JsonPropertyName("creator")]
    public PatreonRelationshipsSingle? Creator { get; set; }

    [JsonPropertyName("address")]
    public PatreonRelationshipsSingle? Address { get; set; }
}
