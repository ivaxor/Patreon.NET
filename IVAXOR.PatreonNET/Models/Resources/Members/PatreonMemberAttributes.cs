using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Members;

/// <summary>
/// The record of a user's membership to a campaign.
/// Remains consistent across months of pledging.
/// </summary>
public class PatreonMemberAttributes : IPatreonAttributes
{
    /// <summary>
    /// The total amount that the member has ever paid to the campaign in campaign's currency.
    /// 0 if never paid.
    /// </summary>
    [JsonPropertyName("campaign_lifetime_support_cents")]
    public int? CampaignLifetimeSupportCents { get; set; }

    /// <summary>
    /// The amount in cents that the member is entitled to.
    /// This includes a current pledge, or payment that covers the current payment period.
    /// </summary>
    [JsonPropertyName("currently_entitled_amount_cents")]
    public int? CurrentlyEntitledAmountCents { get; set; }

    /// <summary>
    /// The member's email address.
    /// Requires the campaigns.members[email] scope.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Full name of the member user.
    /// </summary>
    [JsonPropertyName("full_name")]
    public string? FullName { get; set; }

    /// <summary>
    /// The user is not a pledging patron but has subscribed to updates about public posts.
    /// </summary>
    [JsonPropertyName("is_follower")]
    public bool? IsFollower { get; set; }

    /// <summary>
    /// Datetime of last attempted charge. null if never charged.
    /// </summary>
    [JsonPropertyName("last_charge_date")]
    public DateTime? LastChargeDate { get; set; }

    /// <summary>
    /// The result of the last attempted charge.
    /// The only successful status is Paid.
    /// null if never charged.
    /// One of Paid, Declined, Deleted, Pending, Refunded, Fraud, Other.
    /// </summary>
    [JsonPropertyName("last_charge_status")]
    public string? LastChargeStatus { get; set; }

    /// <summary>
    /// The total amount that the member has ever paid to the campaign.
    /// 0 if never paid.
    /// </summary>
    [JsonPropertyName("lifetime_support_cents")]
    public int? LifetimeSupportCents { get; set; }

    /// <summary>
    /// Datetime of next charge.
    /// null if annual pledge downgrade.
    /// </summary>
    [JsonPropertyName("next_charge_date")]
    public DateTime? NextChargeDate { get; set; }

    /// <summary>
    /// The creator's notes on the member.
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// One of active_patron, declined_patron, former_patron.
    /// A null value indicates the member has never pledged. 
    /// </summary>
    [JsonPropertyName("patron_status")]
    public string? PatronStatus { get; set; }

    /// <summary>
    /// Number of months between charges.
    /// </summary>
    [JsonPropertyName("pledge_cadence")]
    public int? PledgeCadence { get; set; }

    /// <summary>
    /// Datetime of beginning of most recent pledge chain from this member to the campaign.
    /// Pledge updates do not change this value.
    /// </summary>
    [JsonPropertyName("pledge_relationship_start")]
    public DateTime? PledgeRelationshipStart { get; set; }

    /// <summary>
    /// The amount in cents the user will pay at the next pay cycle.
    /// </summary>
    [JsonPropertyName("will_pay_amount_cents")]
    public int? WillPayAmountCents { get; set; }
}
