using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    /// <summary>
    /// Content posted by a creator on a campaign page.
    /// </summary>
    public class PatreonPostV2Attributes
    {
        /// <summary>
        /// Platform app id.
        /// </summary>
        [JsonPropertyName("app_id")]
        public int? AppId { get; set; }

        /// <summary>
        /// Processing status of the post.
        /// </summary>
        [JsonPropertyName("app_status")]
        public string? AppStatus { get; set; }

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        /// <summary>
        /// An object containing embed data if media is embedded in the post
        /// None if there is no embed
        /// </summary>
        [JsonPropertyName("embed_data")]
        public string EmbedData { get; set; }

        /// <summary>
        /// Embed media url.
        /// </summary>
        [JsonPropertyName("embed_url")]
        public string? EmbedUrl { get; set; }

        /// <summary>
        /// True if the post incurs a bill as part of a pay-per-post campaign.
        /// </summary>
        [JsonPropertyName("is_paid")]
        public bool? IsPaid { get; set; }

        /// <summary>
        /// True if the post is viewable by anyone
        /// False if only patrons (or a subset of patrons) can view Can be null.
        /// </summary>
        [JsonPropertyName("is_public")]
        public bool? IsPublic { get; set; }

        /// <summary>
        /// The tier ids that allow the patrons from those tiers to view the post.
        /// Empty array if no tiers assigned even if is_paid is true. 
        /// </summary>
        [JsonPropertyName("tiers")]
        public PatreonTierAttributes[]? Tiers { get; set; }

        /// <summary>
        /// Datetime that the creator most recently published (made publicly visible) the post.
        /// </summary>
        [JsonPropertyName("published_at")]
        public DateTime? PublishedAt { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// A URL to access this post on patreon.com
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
