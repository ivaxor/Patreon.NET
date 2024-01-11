using IVAXOR.PatreonNET.Models.Relationships;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.UsersV1;

public class PatreonUserV1Relationships : IPatreonRelationships
{
    [JsonPropertyName("campaign")]
    public PatreonRelationshipsSingle? Campaign { get; set; }

    [JsonPropertyName("pledges")]
    public PatreonRelationshipsMulti? Pledges { get; set; }
}
