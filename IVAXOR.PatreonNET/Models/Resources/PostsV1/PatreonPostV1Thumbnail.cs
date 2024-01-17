using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV1;

public class PatreonPostV1Thumbnail
{
    [JsonPropertyName("height")]
    public int? Height { get; set; }

    [JsonPropertyName("large")]
    public string? Large { get; set; }

    [JsonPropertyName("large_2")]
    public string? Large2 { get; set; }

    [JsonPropertyName("position")]
    public double? Position { get; set; }

    [JsonPropertyName("square")]
    public string? Square { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("width")]
    public int? Width { get; set; }
}
