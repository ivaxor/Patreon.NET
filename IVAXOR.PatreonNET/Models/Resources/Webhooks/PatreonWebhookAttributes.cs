using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Webhooks;

/// <summary>
/// Webhooks are fired based on events happening on a particular campaign.
/// </summary>
public class PatreonWebhookAttributes : IPatreonAttributes
{
    /// <summary>
    /// Last date that the webhook was attempted or used.
    /// </summary>
    [JsonPropertyName("last_attempted_at")]
    public DateTime? LastAttemptedAt { get; set; }

    /// <summary>
    /// Number of times the webhook has failed consecutively, when in an error state.
    /// </summary>
    [JsonPropertyName("num_consecutive_times_failed")]
    public int? NumConsecutiveTimesFailed { get; set; }

    /// <summary>
    /// true if the webhook is paused as a result of repeated failed attempts to post to uri.
    /// Set to false to attempt to re-enable a previously failing webhook.
    /// </summary>
    [JsonPropertyName("paused")]
    public bool? Paused { get; set; }

    /// <summary>
    /// Secret used to sign your webhook message body, so you can validate authenticity upon receipt.
    /// </summary>
    [JsonPropertyName("secret")]
    public string? Secret { get; set; }

    /// <summary>
    /// List of events that will trigger this webhook.
    /// </summary>
    [JsonPropertyName("triggers")]
    public string? Triggers { get; set; }

    /// <summary>
    /// Fully qualified uri where webhook will be sent.
    /// </summary>
    [JsonPropertyName("uri")]
    public string? Uri { get; set; }
}
