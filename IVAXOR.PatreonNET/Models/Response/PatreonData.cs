using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response
{
    public class PatreonData<TAttributes, TIRelationships>
        where TAttributes : IPatreonAttributes
        where TIRelationships : IPatreonRelationships
    {
        [JsonRequired]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonRequired]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonRequired]
        [JsonPropertyName("attributes")]
        public TAttributes Attributes { get; set; }

        [JsonRequired]
        [JsonPropertyName("relationships")]
        public TIRelationships Relationships { get; set; }
    }
}
