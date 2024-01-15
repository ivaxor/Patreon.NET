using IVAXOR.PatreonNET.Models.Response.Relationships;
using IVAXOR.PatreonNET.Models.Response.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Addresses;

public class PatreonCommentRelationships : IPatreonRelationships
{
    [JsonPropertyName("commenter")]
    public PatreonRelationshipsSingle? Commenter { get; set; }

    [JsonPropertyName("parent")]
    public PatreonRelationshipsSingle? Parent { get; set; }

    [JsonPropertyName("post")]
    public PatreonRelationshipsSingle? Post { get; set; }
}
