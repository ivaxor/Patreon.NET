using IVAXOR.PatreonNET.Models.Relationships;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Members;

public class PatreonMemberRelationships : IPatreonRelationships
{
    /// <summary>
    /// The member's shipping address that they entered for the campaign.
    /// Requires the campaign.members.address scope.
    /// </summary>
    [JsonPropertyName("address")]
    public PatreonRelationshipsSingle? Address { get; set; }

    /// <summary>
    /// The campaign that the membership is for.
    /// </summary>
    [JsonPropertyName("campaign")]
    public PatreonRelationshipsSingle? Campaign { get; set; }

    /// <summary>
    /// The tiers that the member is entitled to.
    /// This includes a current pledge, or payment that covers the current payment period.
    /// </summary>
    [JsonPropertyName("currently_entitled_tiers")]
    public PatreonRelationshipsMulti? CurrentlyEntitledTiers { get; set; }

    /// <summary>
    /// The pledge history of the member.
    /// </summary>
    [JsonPropertyName("pledge_history")]
    public PatreonRelationshipsMulti? PledgeHistory { get; set; }

    /// <summary>
    /// The user who is pledging to the campaign.
    /// </summary>
    [JsonPropertyName("user")]
    public PatreonRelationshipsSingle? User { get; set; }
}
