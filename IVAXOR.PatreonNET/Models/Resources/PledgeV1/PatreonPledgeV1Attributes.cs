using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PledgeV1;

public class PatreonPledgeV1Attributes : IPatreonAttributes
{
    /// <summary>
    /// Based in the patron currency which may be different from the campaign and tier currency.
    /// </summary>
    [JsonPropertyName("amount_cents")]
    public int? AmountCents { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// Indicates the date of the most recent payment if it failed, or `null` if the most recent payment succeeded.
    /// A pledge with a non-null declined_since should be treated as invalid.
    /// </summary>
    [JsonPropertyName("declined_since")]
    public DateTime? DeclinedSince { get; set; }

    [JsonPropertyName("patron_pays_fees")]
    public bool? PatronPaysFees { get; set; }

    [JsonPropertyName("pledge_cap_cents")]
    public int? PledgeCapCents { get; set; }

    /// <summary>
    /// Indicates the lifetime value this patron has paid to the campaign.
    /// </summary>
    [JsonPropertyName("total_historical_amount_cents")]
    public int? TotalHistoricalAmountCents { get; set; }

    [JsonPropertyName("is_paused")]
    public bool? IsPaused { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("has_shipping_address")]
    public bool? HasShippingAddress { get; set; }
}
