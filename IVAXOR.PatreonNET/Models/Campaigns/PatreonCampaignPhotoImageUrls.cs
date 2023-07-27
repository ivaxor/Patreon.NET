using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Campaigns
{
    public class PatreonCampaignPhotoImageUrls
    {
        [JsonRequired]
        [JsonPropertyName("default")]
        public string Default { get; set; }

        [JsonRequired]
        [JsonPropertyName("default_small")]
        public string DefaultSsmall { get; set; }

        [JsonRequired]
        [JsonPropertyName("original")]
        public string Original { get; set; }

        [JsonRequired]
        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonRequired]
        [JsonPropertyName("thumbnail_large")]
        public string ThumbnailLarge { get; set; }

        [JsonRequired]
        [JsonPropertyName("thumbnail_small")]
        public string ThumbnailSmall { get; set; }
    }
}
