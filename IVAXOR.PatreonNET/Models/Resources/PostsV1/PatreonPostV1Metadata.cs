using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV1;

public class PatreonPostV1Metadata
{
    [JsonPropertyName("platform")]
    public PatreonPostV1Platform? Platform { get; set; }
}
