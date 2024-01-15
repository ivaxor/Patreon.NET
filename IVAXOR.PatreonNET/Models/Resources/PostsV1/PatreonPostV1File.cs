using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV1;

public class PatreonPostV1File
{
    [JsonPropertyName("download_url")]
    public string? DownloadUrl { get; set; }

    [JsonPropertyName("duration")]
    public double? Duration { get; set; }

    [JsonPropertyName("duration_s")]
    public double? DurationS { get; set; }

    [JsonPropertyName("expires_at")]
    public DateTime? ExpiresAt { get; set; }

    [JsonPropertyName("full_duration")]
    public double? FullDuration { get; set; }

    [JsonPropertyName("height")]
    public int? Height { get; set; }

    [JsonPropertyName("media_id")]
    public int? MediaId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("progress")]
    public PatreonPostV1Progress? Progress { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("width")]
    public int? Width { get; set; }
}
