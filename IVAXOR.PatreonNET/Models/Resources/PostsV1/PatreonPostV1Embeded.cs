using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV1;

public class PatreonPostV1Embeded
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("html")]
    public string? HTML { get; set; }

    [JsonPropertyName("product_variant_id")]
    public string? Product_variant_id { get; set; }

    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    [JsonPropertyName("provider_url")]
    public string? Provider_url { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
