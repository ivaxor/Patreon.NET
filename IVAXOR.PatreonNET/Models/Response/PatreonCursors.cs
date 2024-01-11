using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response;

public class PatreonCursors
{
    [JsonPropertyName("next")]
    public string? Next { get; set; }
}
