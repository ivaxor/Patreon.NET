using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV1;

public class PatreonPostV1ShareImages
{
    [JsonPropertyName("landscape")]
    public PatreonPostV1ShareImage? Landscape { get; set; }

    [JsonPropertyName("portrait")]
    public PatreonPostV1ShareImage? Portrait { get; set; }
}
