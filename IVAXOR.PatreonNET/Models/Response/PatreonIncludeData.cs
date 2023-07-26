using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response
{
    public class PatreonIncludeData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("attributes")]
        public IPatreonAttributes Attributes { get; set; }

        // TODO: Implement
        [JsonIgnore]
        [JsonPropertyName("relationships")]
        public IPatreonRelationships Relationships { get; set; }
    }
}
