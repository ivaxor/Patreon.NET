using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Responses
{
    public class PatreonMultiDataResponse<TAttributes, TRelationships> : PatreonResponseBase<TAttributes, TRelationships>
        where TAttributes : IPatreonAttributes
        where TRelationships : IPatreonRelationships
    {
        [JsonPropertyName("data")]
        public PatreonResponseData<TAttributes, TRelationships>[] Data { get; set; }
    }
}
