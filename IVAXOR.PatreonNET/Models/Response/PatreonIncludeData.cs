using IVAXOR.PatreonNET.JsonConverters;
using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response
{
    [JsonConverter(typeof(PatreonIncludeDataJsonConverter))]
    public class PatreonIncludeData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("attributes")]
        public IPatreonAttributes Attributes { get; set; }

        [JsonPropertyName("relationships")]
        public IPatreonRelationships Relationships { get; set; }
    }
}
