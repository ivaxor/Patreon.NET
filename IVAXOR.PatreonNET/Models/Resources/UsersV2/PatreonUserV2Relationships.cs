using IVAXOR.PatreonNET.Models.Response.Relationships;
using IVAXOR.PatreonNET.Models.Response.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.UsersV2;

public class PatreonUserV2Relationships : IPatreonRelationships
{
    [JsonPropertyName("memberships")]
    public PatreonRelationshipsMulti? Memberships { get; set; }

    [JsonPropertyName("campaign")]
    public PatreonRelationshipsSingle? Campaign { get; set; }
}
