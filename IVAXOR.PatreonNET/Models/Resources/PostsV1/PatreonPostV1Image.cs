using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV1;

public class PatreonPostV1Image
{
    [JsonPropertyName("height")]
    public int? Height { get; set; }

    [JsonPropertyName("large_url")]
    public string? LargeUrl { get; set; }

    [JsonPropertyName("thumb_square_large_url")]
    public string? ThumbSquareLargeUrl { get; set; }

    [JsonPropertyName("thumb_square_url")]
    public string? ThumbSquareUrl { get; set; }

    [JsonPropertyName("thumb_url")]
    public string? ThumbUrl { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("width")]
    public int? Width { get; set; }
}
