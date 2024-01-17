using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PledgeV1;

public class PatreonPledgeV1Attributes : IPatreonAttributes
{
    [JsonPropertyName("amount_cents")]
    public int? AmountCents { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("declined_since")]
    public DateTime? DeclinedSince { get; set; }

    [JsonPropertyName("patron_pays_fees")]
    public bool? PatronPaysFees { get; set; }

    [JsonPropertyName("pledge_cap_cents")]
    public int? PledgeCapCents { get; set; }

    [JsonPropertyName("total_historical_amount_cents")]
    public int? TotalHistoricalAmountCents { get; set; }

    [JsonPropertyName("is_paused")]
    public bool? IsPaused { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("has_shipping_address")]
    public bool? HasShippingAddress { get; set; }
}
