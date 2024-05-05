using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV1;

public class PatreonPostV1ImageColors
{
    [JsonPropertyName("average_colors_of_corners")]
    public PatreonPostV1AverageColorsOfCorners? AverageColorsOfCorners { get; set; }

    [JsonPropertyName("dominant_color")]
    public string? DominantColor { get; set; }

    [JsonPropertyName("palette")]
    public string[]? Palette { get; set; }

    [JsonPropertyName("text_color")]
    public string? TextColor { get; set; }
}