﻿using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Benefits;

/// <summary>
/// A benefit added to the campaign, which can be added to a tier to be delivered to the patron.
/// </summary>
public class PatreonBenefitAttributes : IPatreonAttributes
{
    /// <summary>
    /// The third-party external ID this reward is associated with, if any.
    /// </summary>
    [JsonPropertyName("app_external_id")]
    public string? AppExternalId { get; set; }

    /// <summary>
    /// Any metadata the third-party app included with this benefit on creation.
    /// </summary>
    [JsonPropertyName("app_meta")]
    public string? AppMeta { get; set; }

    /// <summary>
    /// Type of benefit, such as custom for creator-defined benefits.
    /// </summary>
    [JsonPropertyName("benefit_type")]
    public string? BenefitType { get; set; }

    /// <summary>
    /// Datetime this benefit was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Number of deliverables for this benefit that are due today specifically.
    /// </summary>
    [JsonPropertyName("deliverables_due_today_count")]
    public int? DeliverablesDueTodayCount { get; set; }

    /// <summary>
    /// Number of deliverables for this benefit that have been marked complete.
    /// </summary>
    [JsonPropertyName("delivered_deliverables_count")]
    public int? DeliveredDeliverablesCount { get; set; }

    /// <summary>
    /// Benefit display description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// true if this benefit has been deleted.
    /// </summary>
    [JsonPropertyName("is_deleted")]
    public bool? IsDeleted { get; set; }

    /// <summary>
    /// true if this benefit is no longer available to new patrons
    /// </summary>
    [JsonPropertyName("is_ended")]
    public bool? IsEnded { get; set; }

    /// <summary>
    /// true if this benefit is ready to be fulfilled to patrons.
    /// </summary>
    [JsonPropertyName("is_published")]
    public bool? IsPublished { get; set; }

    /// <summary>
    /// The next due date (after EOD today) for this benefit.
    /// </summary>
    [JsonPropertyName("next_deliverable_due_date")]
    public DateTime? NextDeliverableDueDate { get; set; }

    /// <summary>
    /// Number of deliverables for this benefit that are due, for all dates.
    /// </summary>
    [JsonPropertyName("not_delivered_deliverables_count")]
    public int? NotDeliveredDeliverablesCount { get; set; }

    /// <summary>
    /// A rule type designation, such as eom_monthly or one_time_immediate.
    /// </summary>
    [JsonPropertyName("rule_type")]
    public string? RuleType { get; set; }

    /// <summary>
    /// Number of tiers containing this benefit.
    /// </summary>
    [JsonPropertyName("tiers_count")]
    public int? TiersCount { get; set; }

    /// <summary>
    /// Benefit display title.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
