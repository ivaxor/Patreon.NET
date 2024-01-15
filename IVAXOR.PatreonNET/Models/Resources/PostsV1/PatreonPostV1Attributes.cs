using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV1;

public class PatreonPostV1Attributes : IPatreonAttributes
{
    [JsonPropertyName("comment_count")]
    public int? CommentCount { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("current_user_can_delete")]
    public bool? CurrentUserCanDelete { get; set; }

    [JsonPropertyName("current_user_can_report")]
    public bool? CurrentUserCanReport { get; set; }

    [JsonPropertyName("current_user_can_view")]
    public bool? CurrentUserCanView { get; set; }

    [JsonPropertyName("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [JsonPropertyName("edit_url")]
    public string? EditUrl { get; set; }

    [JsonPropertyName("edited_at")]
    public DateTime? EditedAt { get; set; }

    [JsonPropertyName("embed")]
    public PatreonPostV1Embeded? Embed { get; set; }

    [JsonPropertyName("has_ti_violation")]
    public bool? HasTIViolation { get; set; }

    [JsonPropertyName("image")]
    public PatreonPostV1Image? Image { get; set; }

    [JsonPropertyName("is_automated_monthly_charge")]
    public bool? IsAutomatedMonthlyCharge { get; set; }

    [JsonPropertyName("is_paid")]
    public bool? IsPaid { get; set; }

    [JsonPropertyName("like_count")]
    public int? LikeCount { get; set; }

    [JsonPropertyName("min_cents_pledged_to_view")]
    public int? MinCentsPledgedToView { get; set; }

    [JsonPropertyName("moderation_status")]
    public string? ModerationStatus { get; set; }

    [JsonPropertyName("patreon_url")]
    public string? PatreonUrl { get; set; }

    [JsonPropertyName("pledge_url")]
    public string? PledgeUrl { get; set; }

    [JsonPropertyName("post_file")]
    public PatreonPostV1File? PostFile { get; set; }

    [JsonPropertyName("post_level_suspension_removal_date")]
    public DateTime? PostLevelSuspensionRemovalDate { get; set; }

    [JsonPropertyName("post_metadata")]
    public PatreonPostV1Metadata? PostMetadata { get; set; }

    [JsonPropertyName("post_type")]
    public string? PostType { get; set; }

    [JsonPropertyName("preview_asset_type")]
    public string? PreviewAssetType { get; set; }

    [JsonPropertyName("published_at")]
    public DateTime? PublishedAt { get; set; }

    [JsonPropertyName("scheduled_for")]
    public DateTime? ScheduledFor { get; set; }

    [JsonPropertyName("teaser_text")]
    public string? TeaserText { get; set; }

    [JsonPropertyName("thumbnail")]
    public PatreonPostV1Thumbnail? Thumbnail { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("video_preview")]
    public PatreonPostV1File? VideoPreview { get; set; }

    [JsonPropertyName("was_posted_by_campaign_owner")]
    public bool? WasPostedByCampaignOwner { get; set; }
}
