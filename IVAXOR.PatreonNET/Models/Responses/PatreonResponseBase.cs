using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Responses
{
    public abstract class PatreonResponseBase<TAttributes, TRelationships>
        where TAttributes : IPatreonAttributes
        where TRelationships : IPatreonRelationships
    {
        // TODO: Implement
        [JsonIgnore]
        [JsonPropertyName("included")]
        public string Included { get; set; }

        [JsonPropertyName("links")]
        public PatreonResponseLinks Links { get; set; }
    }
}
