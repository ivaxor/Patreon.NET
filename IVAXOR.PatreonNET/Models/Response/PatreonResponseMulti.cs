using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response
{
    public class PatreonResponseMulti<TAttributes, TIRelationships> : PatreonResponseBase
        where TAttributes : IPatreonAttributes
        where TIRelationships : IPatreonRelationships
    {
        [JsonRequired]
        [JsonPropertyName("data")]
        public PatreonData<TAttributes, TIRelationships>[] Data { get; set; }
    }
}
