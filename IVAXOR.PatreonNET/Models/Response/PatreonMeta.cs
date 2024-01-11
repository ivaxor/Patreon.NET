using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response;

public class PatreonMeta
{
    [JsonRequired]
    [JsonPropertyName("pagination")]
    public PatreonPagination Pagination { get; set; }
}
