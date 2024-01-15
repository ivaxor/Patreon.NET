using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV1;

public class PatreonPostV1Thumbnail
{
    [JsonPropertyName("large")]
    public string? Large { get; set; }

    [JsonPropertyName("large_2")]
    public string? Large_2 { get; set; }

    [JsonPropertyName("square")]
    public string? Square { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
