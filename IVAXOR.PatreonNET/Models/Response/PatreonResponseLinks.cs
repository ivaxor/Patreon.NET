using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response;

public class PatreonResponseLinks
{
    [JsonPropertyName("self")]
    public string? Self { get; set; }

    [JsonPropertyName("first")]
    public string? First { get; set; }

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}
