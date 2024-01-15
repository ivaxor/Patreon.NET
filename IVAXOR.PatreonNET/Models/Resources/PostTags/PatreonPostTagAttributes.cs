using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostTags;

public class PatreonPostTagAttributes : IPatreonAttributes
{
    [JsonPropertyName("background_image_url")]
    public string? BackgroundImageUrl { get; set; }

    [JsonPropertyName("cardinality")]
    public int? Cardinality { get; set; }

    [JsonPropertyName("is_featured")]
    public bool? IsFeatured { get; set; }

    [JsonPropertyName("ordinal_number")]
    public int? OrdinalNumber { get; set; }

    [JsonPropertyName("tag_type")]
    public string? TagType { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
