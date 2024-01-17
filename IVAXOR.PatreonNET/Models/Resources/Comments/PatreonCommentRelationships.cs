using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Comments;

public class PatreonCommentRelationships : IPatreonRelationships
{
    [JsonPropertyName("commenter")]
    public PatreonRelationshipsSingle? Commenter { get; set; }

    [JsonPropertyName("parent")]
    public PatreonRelationshipsSingle? Parent { get; set; }

    [JsonPropertyName("post")]
    public PatreonRelationshipsSingle? Post { get; set; }
}
