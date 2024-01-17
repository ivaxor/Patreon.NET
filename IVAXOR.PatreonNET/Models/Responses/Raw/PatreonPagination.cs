using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Responses.Raw;

public class PatreonPagination
{
    [JsonPropertyName("cursors")]
    public PatreonCursors? Cursors { get; set; }

    [JsonPropertyName("total")]
    public int? Total { get; set; }
}
