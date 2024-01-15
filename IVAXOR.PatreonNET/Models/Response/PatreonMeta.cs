using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response;

public class PatreonMeta
{
    [JsonPropertyName("pagination")]
    public PatreonPagination? Pagination { get; set; }

    [JsonPropertyName("count")]
    public int? Count { get; set; }

    [JsonPropertyName("posts_count")]
    public int? PostsCount { get; set; }
}
