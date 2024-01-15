using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV1;

public class PatreonPostV1Metadata
{
    [JsonPropertyName("image_order")]
    public string[]? ImageOrder { get; set; }

    [JsonPropertyName("platform")]
    public PatreonPostV1Platform? Platform { get; set; }
}
