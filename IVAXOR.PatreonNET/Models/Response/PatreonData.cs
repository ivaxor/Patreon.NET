using IVAXOR.PatreonNET.Models.Response.Interfaces;
using IVAXOR.PatreonNET.Models.Response.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response;

public class PatreonData<TAttributes, TRelationships>
    where TAttributes : IPatreonAttributes
    where TRelationships : IPatreonRelationships
{
    [JsonRequired]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonRequired]
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("attributes")]
    public TAttributes? Attributes { get; set; }

    [JsonPropertyName("relationships")]
    public TRelationships? Relationships { get; set; }
}
