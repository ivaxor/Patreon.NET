using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Users
{
    public class PatreonUserV2Attributes : IPatreonAttributes
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
        public DateTime Created { get; set; }

        [JsonPropertyName("default_country_code")]
        public string? DefaultCountryCode { get; set; }

        [JsonPropertyName("discord_id")]
        public string? DiscordId { get; set; }

        /// <summary>
        /// The user's email address.
        /// Requires certain scopes to access.
        /// See the scopes section of this documentation.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("facebook")]
        public string? Facebook { get; set; }

        [JsonPropertyName("facebook_id")]
        public string? FacebookId { get; set; }

        /// <summary>
        /// First name.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Combined first and last name.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonRequired]
        [JsonPropertyName("gender")]
        public int Gender { get; set; }

        [JsonPropertyName("google_id")]
        public string? GoogleId { get; set; }

        [JsonRequired]
        [JsonPropertyName("has_password")]
        public bool HasPassword { get; set; }

        /// <summary>
        /// The user's profile picture URL, scaled to width 400px.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [JsonRequired]
        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonRequired]
        [JsonPropertyName("is_eligible_for_idv")]
        public bool IsEligibleForIdv { get; set; }

        /// <summary>
        /// true if the user has confirmed their email.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("is_email_verified")]
        public bool IsEmailVerified { get; set; }

        [JsonRequired]
        [JsonPropertyName("is_nuked")]
        public bool IsNuked { get; set; }

        [JsonRequired]
        [JsonPropertyName("is_suspended")]
        public bool IsSuspended { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("patron_currency")]
        public string? PatronCurrency { get; set; }

        /// <summary>
        /// Mapping from user's connected app names to external user id on the respective app.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("social_connections")]
        public PatreonUserV2SocialConnections SocialConnections { get; set; }

        /// <summary>
        /// The user's profile picture URL, scaled to a square of size 100x100px.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("thumb_url")]
        public string ThumbUrl { get; set; }

        [JsonPropertyName("twitch")]
        public string? Twitch { get; set; }

        [JsonPropertyName("twitter")]
        public string? Twitter { get; set; }

        /// <summary>
        /// URL of this user's creator or patron profile.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("url")]
        public string Url { get; set; }

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
