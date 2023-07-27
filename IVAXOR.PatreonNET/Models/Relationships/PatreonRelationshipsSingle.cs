using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Relationships
{
    public class PatreonRelationshipsSingle
    {
        [JsonRequired]
        [JsonPropertyName("data")]
        public PatreonRelationshipsData Data { get; set; }

        [JsonRequired]
        [JsonPropertyName("links")]
        public PatreonRelationshipsLinks? Links { get; set; }
    }
}
