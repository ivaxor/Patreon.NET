using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Tiers;

public class PatreonTierAttributes : IPatreonAttributes
{
    /// <summary>
    /// Monetary amount associated with this tier (in U.S. cents).
    /// </summary>
    [JsonPropertyName("amount_cents")]
    public int? AmountCents { get; set; }

    /// <summary>
    /// Datetime this tier was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Tier display description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The discord role IDs granted by this tier.
    /// </summary>
    [JsonPropertyName("discord_role_ids")]
    public string? DiscordRoleIds { get; set; }

    /// <summary>
    /// Datetime tier was last modified.
    /// </summary>
    [JsonPropertyName("edited_at")]
    public DateTime? EditedAt { get; set; }

    /// <summary>
    /// Full qualified image URL associated with this tier.
    /// </summary>
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Number of patrons currently registered for this tier.
    /// </summary>
    [JsonPropertyName("patron_count")]
    public int? PatronCount { get; set; }

    /// <summary>
    /// Number of posts published to this tier.
    /// </summary>
    [JsonPropertyName("post_count")]
    public int? PostCount { get; set; }

    /// <summary>
    /// true if the tier is currently published.
    /// </summary>
    [JsonPropertyName("published")]
    public bool? Published { get; set; }

    /// <summary>
    /// Datetime this tier was last published. 
    /// </summary>
    [JsonPropertyName("published_at")]
    public DateTime? PublishedAt { get; set; }

    /// <summary>
    /// Remaining number of patrons who may subscribe, if there is a user_limit.
    /// </summary>
    [JsonPropertyName("remaining")]
    public int? Remaining { get; set; }

    /// <summary>
    /// true if this tier requires a shipping address from patrons.
    /// </summary>
    [JsonPropertyName("requires_shipping")]
    public bool? RequiresShipping { get; set; }

    /// <summary>
    /// Tier display title.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Datetime tier was unpublished, while applicable.
    /// </summary>
    [JsonPropertyName("unpublished_at")]
    public DateTime? UnpublishedAt { get; set; }

    /// <summary>
    /// Fully qualified URL associated with this tier.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Maximum number of patrons this tier is limited to, if applicable.
    /// </summary>
    [JsonPropertyName("user_limit")]
    public int? UserLimit { get; set; }
}
