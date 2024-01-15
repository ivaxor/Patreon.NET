using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.CampaignsV1;

public class PatreonCampaignV1CoverPhotoUrlSizes
{
    [JsonPropertyName("large")]
    public string? Large { get; set; }

    [JsonPropertyName("medium")]
    public string? Medium { get; set; }

    [JsonPropertyName("small")]
    public string? Small { get; set; }
}
