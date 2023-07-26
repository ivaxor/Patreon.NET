using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Relationships
{
    public class PatreonRelationshipsSingle
    {
        [JsonPropertyName("data")]
        public PatreonRelationshipsData Data { get; set; }

        [JsonPropertyName("links")]
        public PatreonRelationshipsLinks? Links { get; set; }
    }
}
