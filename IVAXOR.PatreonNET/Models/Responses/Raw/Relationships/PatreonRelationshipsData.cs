using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Responses.Raw.Relationships;

public class PatreonRelationshipsData
{
    [JsonRequired]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonRequired]
    [JsonPropertyName("type")]
    public string Type { get; set; }
}
