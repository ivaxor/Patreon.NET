using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Users
{
    public class PatreonUserAttributes : IPatreonAttributes
    {
        /// <summary>
        /// The user's about text, which appears on their profile.
        /// </summary>
        [JsonPropertyName("about")]
        public string? About { get; set; }

        [JsonPropertyName("age_verification_status")]
        public string? AgeVerificationStatus { get; set; }

        [JsonPropertyName("apple_id")]
        public string? AppleId { get; set; }

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

        [JsonPropertyName("current_user_block_status")]
        public string? CurrentUserBlockStatus { get; set; }

        [JsonPropertyName("default_country_code")]
        public string? DefaultCountryCode { get; set; }

        [JsonPropertyName("discord_id")]
        public string? DiscordId { get; set; }

        /// <summary>
        /// The user's email address.
        /// Requires certain scopes to access.
        /// See the scopes section of this documentation.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("facebook")]
        public string? Facebook { get; set; }

        [JsonPropertyName("facebook_id")]
        public string? FacebookId { get; set; }

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

        [JsonPropertyName("gender")]
        public int? Gender { get; set; }

        [JsonPropertyName("google_id")]
        public string? GoogleId { get; set; }

        [JsonPropertyName("has_password")]
        public bool? HasPassword { get; set; }

        /// <summary>
        /// The user's profile picture URL, scaled to width 400px.
        /// </summary>
        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool? IsDeleted { get; set; }

        [JsonPropertyName("is_eligible_for_idv")]
        public bool? IsEligibleForIdv { get; set; }

        /// <summary>
        /// true if the user has confirmed their email.
        /// </summary>
        [JsonPropertyName("is_email_verified")]
        public bool? IsEmailVerified { get; set; }

        [JsonPropertyName("is_nuked")]
        public bool? IsNuked { get; set; }

        [JsonPropertyName("is_suspended")]
        public bool? IsSuspended { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("patron_currency")]
        public string? PatronCurrency { get; set; }

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

        [JsonPropertyName("twitch")]
        public string? Twitch { get; set; }

        [JsonPropertyName("twitter")]
        public string? Twitter { get; set; }

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

        [JsonPropertyName("youtube")]
        public string? Youtube { get; set; }
    }
}
