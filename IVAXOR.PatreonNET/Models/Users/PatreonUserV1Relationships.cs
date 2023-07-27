using IVAXOR.PatreonNET.Models.Interfaces;
using IVAXOR.PatreonNET.Models.Relationships;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Users
{
    public class PatreonUserV1Relationships : IPatreonRelationships
    {
        [JsonPropertyName("campaign")]
        public PatreonRelationshipsSingle? Campaign { get; set; }

        [JsonRequired]
        [JsonPropertyName("pledges")]
        public PatreonRelationshipsMulti Pledges { get; set; }
    }
}
