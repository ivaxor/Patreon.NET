using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Responses
{
    public class PatreonData<TAttributes, TIRelationships>
        where TAttributes : IPatreonAttributes
        where TIRelationships : IPatreonRelationships
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("attributes")]
        public TAttributes Attributes { get; set; }

        [JsonPropertyName("relationships")]
        public TIRelationships Relationships { get; set; }
    }
}
