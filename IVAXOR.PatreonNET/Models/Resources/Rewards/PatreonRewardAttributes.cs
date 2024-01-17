using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Rewards;

public class PatreonRewardAttributes : IPatreonAttributes
{
    [JsonPropertyName("amount")]
    public int? Amount { get; set; }

    [JsonPropertyName("amount_cents")]
    public int? AmountCents { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("declined_patron_count")]
    public int? DeclinedPatronCount { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("discord_role_ids")]
    public string[]? DiscordRoleIds { get; set; }

    [JsonPropertyName("edited_at")]
    public DateTime? EditedAt { get; set; }

    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("is_free_tier")]
    public bool? IsFreeTier { get; set; }

    [JsonPropertyName("patron_amount_cents")]
    public int? PatronAmountCents { get; set; }

    [JsonPropertyName("patron_count")]
    public int? PatronCount { get; set; }

    [JsonPropertyName("patron_currency")]
    public string? PatronCurrency { get; set; }

    [JsonPropertyName("post_count")]
    public int? PostCount { get; set; }

    [JsonPropertyName("published")]
    public bool? Published { get; set; }

    [JsonPropertyName("published_at")]
    public DateTime? PublishedAt { get; set; }

    [JsonPropertyName("remaining")]
    public int? Remaining { get; set; }

    [JsonPropertyName("requires_shipping")]
    public bool? RequiresShipping { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("unpublished_at")]
    public DateTime? UnpublishedAt { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("user_limit")]
    public int? UserLimit { get; set; }

    [JsonPropertyName("welcome_message")]
    public string? WelcomeMessage { get; set; }

    [JsonPropertyName("welcome_message_unsafe")]
    public string? WelcomeMessageUnsafe { get; set; }

    [JsonPropertyName("welcome_video_embed")]
    public string? WelcomeVideoEmbed { get; set; }

    [JsonPropertyName("welcome_video_url")]
    public string? WelcomeVideoUrl { get; set; }
}
