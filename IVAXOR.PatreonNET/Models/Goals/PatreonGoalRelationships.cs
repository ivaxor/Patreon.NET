using IVAXOR.PatreonNET.Models.Relationships;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Goals;

public class PatreonGoalRelationships : IPatreonRelationships
{
    /// <summary>
    /// The campaign trying to reach the goal.
    /// </summary>
    [JsonPropertyName("campaign")]
    public PatreonRelationshipsSingle? Campaign { get; set; }
}