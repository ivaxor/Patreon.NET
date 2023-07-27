using IVAXOR.PatreonNET.Models.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonRewardAttributes : IPatreonAttributes
    {
        [JsonRequired]
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonRequired]
        [JsonPropertyName("amount_cents")]
        public int AmountCents { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonRequired]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonRequired]
        [JsonPropertyName("patron_currency")]
        public string PatronCurrency { get; set; }

        [JsonRequired]
        [JsonPropertyName("remaining")]
        public int Remaining { get; set; }

        [JsonRequired]
        [JsonPropertyName("requires_shipping")]
        public bool RequiresShipping { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("user_limit")]
        public int? UserLimit { get; set; }
    }
}
