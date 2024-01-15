using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV1;

public class PatreonPostV1Progress
{
    [JsonPropertyName("is_watched")]
    public bool? IsWatched { get; set; }

    [JsonPropertyName("watch_state")]
    public string? WatchState { get; set; }
}
