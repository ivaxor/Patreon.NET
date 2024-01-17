using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV1;

public class PatreonPostV1Relationships : IPatreonRelationships
{
    [JsonPropertyName("attachments")]
    public PatreonRelationshipsMulti? Attachments { get; set; }

    [JsonPropertyName("campaign")]
    public PatreonRelationshipsSingle? Campaign { get; set; }

    [JsonPropertyName("content_locks")]
    public PatreonRelationshipsMulti? ContentLocks { get; set; }

    [JsonPropertyName("likes")]
    public PatreonRelationshipsMulti? Likes { get; set; }

    [JsonPropertyName("comments")]
    public PatreonRelationshipsMulti? Comments { get; set; }

    [JsonPropertyName("user")]
    public PatreonRelationshipsSingle? User { get; set; }

    [JsonPropertyName("user_defined_tags")]
    public PatreonRelationshipsMulti? UserDefinedTags { get; set; }
}
