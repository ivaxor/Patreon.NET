using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV1;

public class PatreonPostV1ShareImage
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
