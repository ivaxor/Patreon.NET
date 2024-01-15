using IVAXOR.PatreonNET.Models.Resources.Users;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.UsersV2;

public class PatreonUserV2Attributes : IPatreonAttributes
{
    /// <summary>
    /// The user's about text, which appears on their profile.
    /// </summary>
    [JsonPropertyName("about")]
    public string? About { get; set; }

    /// <summary>
    /// true if this user can view nsfw content.
    /// </summary>
    [JsonPropertyName("can_see_nsfw")]
    public bool? CanSeeNsfw { get; set; }

    /// <summary>
    /// Datetime of this user's account creation.
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    /// <summary>
    /// The user's email address.
    /// Requires certain scopes to access.
    /// See the scopes section of this documentation.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// First name.
    /// </summary>
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    /// <summary>
    /// Combined first and last name.
    /// </summary>
    [JsonPropertyName("full_name")]
    public string? FullName { get; set; }

    /// <summary>
    /// true if the user has chosen to keep private which creators they pledge to.
    /// </summary>
    [JsonPropertyName("hide_pledges")]
    public bool? HidePledges { get; set; }

    /// <summary>
    /// The user's profile picture URL, scaled to width 400px.
    /// </summary>
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    /// <summary>
    /// true if the user has confirmed their email.
    /// </summary>
    [JsonPropertyName("is_email_verified")]
    public bool? IsEmailVerified { get; set; }

    /// <summary>
    /// Last name.
    /// </summary>
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    /// <summary>
    /// How many posts this user has liked.
    /// </summary>
    [JsonPropertyName("like_count")]
    public int? LikeCount { get; set; }

    /// <summary>
    /// Mapping from user's connected app names to external user id on the respective app.
    /// </summary>
    [JsonPropertyName("social_connections")]
    public PatreonUserSocialConnections? SocialConnections { get; set; }

    /// <summary>
    /// The user's profile picture URL, scaled to a square of size 100x100px.
    /// </summary>
    [JsonPropertyName("thumb_url")]
    public string? ThumbUrl { get; set; }

    /// <summary>
    /// URL of this user's creator or patron profile.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Deprecated! Use campaign.vanity
    /// The public "username" of the user. patreon.com/ goes to this user's creator page.
    /// Non-creator users might not have a vanity.
    /// </summary>
    [Obsolete("Use campaign.vanity")]
    [JsonPropertyName("vanity")]
    public string? Vanity { get; set; }
}
