using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Pledges
{
    /// <summary>
    /// The record of a pledging action taken by the user, or that action's failure.
    /// </summary>
    public class PatreonPledgeEventAttributes : IPatreonAttributes
    {
        /// <summary>
        /// Amount (in the currency in which the patron paid) of the underlying event.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("amount_cents")]
        public int AmountCents { get; set; }

        /// <summary>
        /// ISO code of the currency of the event.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The date which this event occurred.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Status of underlying payment.
        /// One of Paid, Declined, Deleted, Pending, Refunded, Fraud, Other
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("payment_status")]
        public string PaymentStatus { get; set; }

        /// <summary>
        /// Id of the tier associated with the pledge.
        /// </summary>
        [JsonPropertyName("tier_id")]
        public string? TierId { get; set; }

        /// <summary>
        /// Title of the reward tier associated with the pledge.
        /// </summary>
        [JsonPropertyName("tier_title")]
        public string? TierTitle { get; set; }

        /// <summary>
        /// Event type.
        /// One of pledge_start, pledge_upgrade, pledge_downgrade, pledge_delete, subscription
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
