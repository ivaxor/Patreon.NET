using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV2;

public class PatreonEmbedData
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("html")]
    public string? HTML { get; set; }

    [JsonPropertyName("product_variant_id")]
    public string? ProductVariantId { get; set; }

    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    [JsonPropertyName("provider_url")]
    public string? ProviderUrl { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
