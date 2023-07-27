using IVAXOR.PatreonNET.Models.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Campaigns
{
    /// <summary>
    /// The creator's page, and the top-level object for accessing lists of members, tiers, etc.
    /// </summary>
    public class PatreonCampaignV2Attributes : IPatreonAttributes
    {
        [JsonRequired]
        [JsonPropertyName("avatar_photo_image_urls")]
        public PatreonCampaignPhotoImageUrls AvatarPhotoImageUrls { get; set; }

        [JsonRequired]
        [JsonPropertyName("avatar_photo_url")]
        public string AvatarPhotoUrl { get; set; }

        [JsonRequired]
        [JsonPropertyName("campaign_pledge_sum")]
        public int CampaignPledgeSum { get; set; }

        [JsonRequired]
        [JsonPropertyName("cover_photo_url")]
        public string? CoverPhotoUrl { get; set; }

        // TODO: Investigate schema
        [JsonIgnore]
        //[JsonRequired]
        [JsonPropertyName("cover_photo_url_sizes")]
        public object CoverPhotUrlSizes { get; set; }

        /// <summary>
        /// Datetime that the creator first began the campaign creation process.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonRequired]
        [JsonPropertyName("creation_count")]
        public int CreationCount { get; set; }

        /// <summary>
        /// The type of content the creator is creating, as in "vanity is creating creation_name".
        /// </summary>
        [JsonPropertyName("creation_name")]
        public string? CreationName { get; set; }

        [JsonRequired]
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The ID of the external discord server that is linked to this campaign.
        /// </summary>
        [JsonPropertyName("discord_server_id")]
        public string? DiscordServerId { get; set; }

        [JsonRequired]
        [JsonPropertyName("display_patron_goals")]
        public bool DisplayPatronGoals { get; set; }

        /// <summary>
        /// Whether the campaign's total earnings are shown publicly.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("earnings_visibility")]
        public string EarningsVisibility { get; set; }

        /// <summary>
        /// URL for the campaign's profile image.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("image_small_url")]
        public string ImageSmallUrl { get; set; }

        /// <summary>
        /// Banner image URL for the campaign.
        /// </summary>
        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; set; }

        [JsonRequired]
        [JsonPropertyName("is_charge_upfront")]
        public bool IsChargeUpfront { get; set; }

        /// <summary>
        /// true if the campaign charges upfront, false otherwise.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("is_charged_immediately")]
        public bool IsChargedImmediately { get; set; }

        /// <summary>
        /// true if the campaign charges per month, false if the campaign charges per-post.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("is_monthly")]
        public bool IsMonthly { get; set; }

        /// <summary>
        /// true if the creator has marked the campaign as containing nsfw content.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("is_nsfw")]
        public bool IsNsfw { get; set; }

        [JsonRequired]
        [JsonPropertyName("is_plural")]
        public bool IsPlural { get; set; }

        [JsonPropertyName("main_video_embed")]
        public string? MainVideoEmbed { get; set; }

        [JsonPropertyName("main_video_url")]
        public string? MainVideoUrl { get; set; }

        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Pithy one-liner for this campaign, displayed on the creator page.
        /// </summary>
        [JsonPropertyName("one_liner")]
        public string? OneLiner { get; set; }

        [JsonRequired]
        [JsonPropertyName("outstanding_payment_amount_cents")]
        public int OutstandingPaymentAmountCents { get; set; }

        [JsonRequired]
        [JsonPropertyName("paid_member_count")]
        public int PaidMemberCcount { get; set; }

        /// <summary>
        /// Number of patrons pledging to this creator.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("patron_count")]
        public int PatronCount { get; set; }

        /// <summary>
        /// The thing which patrons are paying per, as in "vanity is making $1000 per pay_per_name".
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("pay_per_name")]
        public string PayPerName { get; set; }

        [JsonRequired]
        [JsonPropertyName("pledge_sum")]
        public int PledgeSum { get; set; }

        [JsonRequired]
        [JsonPropertyName("pledge_sum_currency")]
        public string PledgeSumCurrency { get; set; }

        /// <summary>
        /// Relative (to patreon.com) URL for the pledge checkout flow for this campaign.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("pledge_url")]
        public string PledgeUrl { get; set; }

        /// <summary>
        /// Datetime that the creator most recently published (made publicly visible) the campaign.
        /// </summary>
        [JsonPropertyName("published_at")]
        public DateTime? PublishedAt { get; set; }

        /// <summary>
        /// The creator's summary of their campaign.
        /// </summary>
        [JsonPropertyName("summary")]
        public string? Summary { get; set; }

        [JsonPropertyName("thanks_embed")]
        public string? ThanksEmbed { get; set; }

        /// <summary>
        /// Thank you message shown to patrons after they pledge to this campaign.
        /// </summary>
        [JsonPropertyName("thanks_msg")]
        public string? ThanksMsg { get; set; }

        /// <summary>
        /// URL for the video shown to patrons after they pledge to this campaign.
        /// </summary>
        [JsonPropertyName("thanks_video_url")]
        public string? ThanksVideoUrl { get; set; }

        /// <summary>
        /// A URL to access this campaign on patreon.com
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
