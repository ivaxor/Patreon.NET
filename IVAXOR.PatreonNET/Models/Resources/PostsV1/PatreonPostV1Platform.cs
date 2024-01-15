using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV1;

public class PatreonPostV1Platform
{
    [JsonPropertyName("app_id")]
    public string? AppId { get; set; }
}
