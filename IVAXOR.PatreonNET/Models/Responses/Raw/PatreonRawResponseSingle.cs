using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Responses.Raw;

public class PatreonRawResponseSingle<TAttributes, TRelationships> : PatreonRawResponseBase, IPatreonResponse<TAttributes, TRelationships>
    where TAttributes : IPatreonAttributes
    where TRelationships : IPatreonRelationships
{
    [JsonRequired]
    [JsonPropertyName("data")]
    public PatreonData<TAttributes, TRelationships> Data { get; set; }
}
