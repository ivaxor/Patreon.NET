using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Responses
{
    public class PatreonResponseSingle<TAttributes, TIRelationships> : PatreonResponseBase
        where TAttributes : IPatreonAttributes
        where TIRelationships : IPatreonRelationships
    {
        [JsonPropertyName("data")]
        public PatreonData<TAttributes, TIRelationships> Data { get; set; }
    }
}
