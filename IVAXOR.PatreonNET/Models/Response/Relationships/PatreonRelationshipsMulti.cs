using IVAXOR.PatreonNET.Models.Response;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response.Relationships;

public class PatreonRelationshipsMulti
{
    [JsonPropertyName("data")]
    public PatreonRelationshipsData[]? Data { get; set; }

    [JsonPropertyName("links")]
    public PatreonLinks? Links { get; set; }

    [JsonPropertyName("meta")]
    public PatreonMeta? Meta { get; set; }
}
