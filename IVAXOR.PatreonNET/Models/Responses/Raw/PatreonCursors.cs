using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Responses.Raw;

public class PatreonCursors
{
    [JsonPropertyName("next")]
    public string? Next { get; set; }
}
