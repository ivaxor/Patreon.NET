using IVAXOR.PatreonNET.Models.Relationships;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Deliverables;

public class PatreonDeliverableRelationships : IPatreonRelationships
{
    /// <summary>
    /// The Benefit the Deliverables were generated for.
    /// </summary>
    [JsonPropertyName("benefit")]
    public PatreonRelationshipsSingle? Benefit { get; set; }

    /// <summary>
    /// The Campaign the Deliverables were generated for.
    /// </summary>
    [JsonPropertyName("campaign")]
    public PatreonRelationshipsSingle? Campaign { get; set; }

    /// <summary>
    /// The member who has been granted the deliverable.
    /// </summary>
    [JsonPropertyName("member")]
    public PatreonRelationshipsSingle? Member { get; set; }

    /// <summary>
    /// The user who has been granted the deliverable.
    /// This user is the same as the member user.
    /// </summary>
    [JsonPropertyName("user")]
    public PatreonRelationshipsSingle? User { get; set; }
}
