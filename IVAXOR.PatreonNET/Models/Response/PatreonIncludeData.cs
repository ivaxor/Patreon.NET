using IVAXOR.PatreonNET.JsonConverters;
using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response
{
    [JsonConverter(typeof(PatreonIncludeDataJsonConverter))]
    public class PatreonIncludeData
    {
        [JsonRequired]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonRequired]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonRequired]
        [JsonPropertyName("attributes")]
        public IPatreonAttributes Attributes { get; set; }

        [JsonRequired]
        [JsonPropertyName("relationships")]
        public IPatreonRelationships Relationships { get; set; }
    }
}
