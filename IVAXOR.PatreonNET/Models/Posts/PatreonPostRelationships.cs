using IVAXOR.PatreonNET.Models.Relationships;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Posts;

public class PatreonPostRelationships : IPatreonRelationships
{
    /// <summary>
    /// The author of the post.
    /// </summary>
    [JsonPropertyName("user")]
    public PatreonRelationshipsSingle? User { get; set; }

    /// <summary>
    /// The campaign that the membership is for.
    /// </summary>
    [JsonPropertyName("campaign")]
    public PatreonRelationshipsSingle? Campaign { get; set; }
}