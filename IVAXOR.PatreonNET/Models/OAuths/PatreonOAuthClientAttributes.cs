using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.OAuths
{
    /// <summary>
    /// A client created by a developer, used for getting OAuth2 access tokens.
    /// </summary>
    public class PatreonOAuthClientAttributes : IPatreonAttributes
    {
        /// <summary>
        /// The author name provided during client setup.
        /// </summary>
        [JsonPropertyName("author_name")]
        public string? AuthorName { get; set; }

        /// <summary>
        /// The client's secret.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Deprecated in APIv2
        /// The client's default OAuth scopes for the authorization flow.
        /// </summary>
        [JsonRequired]
        [Obsolete("Deprecated in APIv2")]
        [JsonPropertyName("default_scopes")]
        public string DefaultScopes { get; set; }

        /// <summary>
        /// The description provided during client setup.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The domain provided during client setup.
        /// </summary>
        [JsonPropertyName("domain")]
        public string? Domain { get; set; }

        /// <summary>
        /// The URL of the icon used in the OAuth authorization flow.
        /// </summary>
        [JsonPropertyName("icon_url")]
        public string? iconUrl { get; set; }

        /// <summary>
        /// The name provided during client setup.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The URL of the privacy policy provided during client setup.
        /// </summary>
        [JsonPropertyName("privacy_policy_url")]
        public string? PrivacyPolicyUrl { get; set; }

        /// <summary>
        /// The allowable redirect URIs for the OAuth authorization flow.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("redirect_uris")]
        public string RedirectUris { get; set; }

        /// <summary>
        /// The URL of the terms of service provided during client setup.
        /// </summary>
        [JsonPropertyName("tos_url")]
        public string? TosUrl { get; set; }

        /// <summary>
        /// The Patreon API version the client is targeting.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
