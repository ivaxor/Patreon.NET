using IVAXOR.PatreonNET.Models.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Addresses
{
    /// <summary>
    /// A patron's shipping address.
    /// </summary>
    public class PatreonAddressAttributes : IPatreonAttributes
    {
        /// <summary>
        /// Full recipient name.
        /// </summary>
        [JsonPropertyName("addressee")]
        public string? Addressee { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// Country.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Datetime address was first created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// First line of street address.
        /// </summary>
        [JsonPropertyName("line_1")]
        public string? Line1 { get; set; }

        /// <summary>
        /// Second line of street address.
        /// </summary>
        [JsonPropertyName("line_2")]
        public string? Line2 { get; set; }

        /// <summary>
        /// Telephone number.
        /// Specified for non-US addresses.
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Postal or zip code.
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }

        /// <summary>
        /// State or province name.
        /// </summary>
        [JsonPropertyName("state")]
        public string? State { get; set; }
    }
}
