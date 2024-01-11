using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response;

public class PatreonMeta
{
    [JsonPropertyName("pagination")]
    public PatreonPagination? Pagination { get; set; }

    [JsonPropertyName("count")]
    public int? Count { get; set; }
}
