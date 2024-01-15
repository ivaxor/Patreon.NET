using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response.Relationships;

public class PatreonRelationshipsSingle
{
    [JsonPropertyName("data")]
    public PatreonRelationshipsData? Data { get; set; }

    [JsonPropertyName("links")]
    public PatreonLinks? Links { get; set; }

    [JsonPropertyName("meta")]
    public PatreonMeta? Meta { get; set; }
}
