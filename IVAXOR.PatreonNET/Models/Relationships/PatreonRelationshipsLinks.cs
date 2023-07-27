using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Relationships
{
    public class PatreonRelationshipsLinks
    {
        [JsonRequired]
        [JsonPropertyName("related")]
        public string Related { get; set; }
    }
}
