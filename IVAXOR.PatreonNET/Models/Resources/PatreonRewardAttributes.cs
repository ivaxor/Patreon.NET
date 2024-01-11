using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources;

public class PatreonRewardAttributes : IPatreonAttributes
{
    [JsonPropertyName("amount")]
    public int? Amount { get; set; }

    [JsonPropertyName("amount_cents")]
    public int? AmountCents { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("patron_currency")]
    public string? PatronCurrency { get; set; }

    [JsonPropertyName("remaining")]
    public int? Remaining { get; set; }

    [JsonPropertyName("requires_shipping")]
    public bool? RequiresShipping { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("user_limit")]
    public int? UserLimit { get; set; }
}
