using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Relationships
{
    public class PatreonRelationshipsMulti
    {
        [JsonRequired]
        [JsonPropertyName("data")]
        public PatreonRelationshipsData[] Data { get; set; }
    }
}
