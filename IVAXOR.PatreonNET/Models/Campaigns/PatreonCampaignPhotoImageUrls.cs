﻿using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Campaigns;

public class PatreonCampaignPhotoImageUrls
{
    [JsonPropertyName("default")]
    public string? Default { get; set; }

    [JsonPropertyName("default_small")]
    public string? DefaultSsmall { get; set; }

    [JsonPropertyName("original")]
    public string? Original { get; set; }

    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; set; }

    [JsonPropertyName("thumbnail_large")]
    public string? ThumbnailLarge { get; set; }

    [JsonPropertyName("thumbnail_small")]
    public string? ThumbnailSmall { get; set; }
}
