using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.UsersV2;

public class PatreonUserV2SocialConnections
{
    [JsonPropertyName("deviantart")]
    public PatreonUserV2SocialConnection? Deviantart { get; set; }

    [JsonPropertyName("discord")]
    public PatreonUserV2SocialConnection? Discord { get; set; }

    [JsonPropertyName("facebook")]
    public PatreonUserV2SocialConnection? Facebook { get; set; }

    [JsonPropertyName("google")]
    public PatreonUserV2SocialConnection? Google { get; set; }

    [JsonPropertyName("instagram")]
    public PatreonUserV2SocialConnection? Instagram { get; set; }

    [JsonPropertyName("reddit")]
    public PatreonUserV2SocialConnection? Reddit { get; set; }

    [JsonPropertyName("spotify")]
    public PatreonUserV2SocialConnection? Spotify { get; set; }

    [JsonPropertyName("spotify_open_access")]
    public PatreonUserV2SocialConnection? SpotifyOpenAccess { get; set; }

    [JsonPropertyName("twitch")]
    public PatreonUserV2SocialConnection? Twitch { get; set; }

    [JsonPropertyName("twitter")]
    public PatreonUserV2SocialConnection? Twitter { get; set; }

    [JsonPropertyName("vimeo")]
    public PatreonUserV2SocialConnection? Vimeo { get; set; }

    [JsonPropertyName("youtube")]
    public PatreonUserV2SocialConnection? Youtube { get; set; }
}
