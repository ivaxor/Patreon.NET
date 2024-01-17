using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Responses.Raw;

public class PatreonLinks
{
    [JsonPropertyName("self")]
    public string? Self { get; set; }

    [JsonPropertyName("related")]
    public string? Related { get; set; }

    [JsonPropertyName("first")]
    public string? First { get; set; }

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}
