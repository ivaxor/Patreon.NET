using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.UsersV1;

public class PatreonUserV2SocialConnections
{
    [JsonPropertyName("deviantart")]
    public PatreonUserV1SocialConnection? Deviantart { get; set; }

    [JsonPropertyName("discord")]
    public PatreonUserV1SocialConnection? Discord { get; set; }

    [JsonPropertyName("facebook")]
    public PatreonUserV1SocialConnection? Facebook { get; set; }

    [JsonPropertyName("google")]
    public PatreonUserV1SocialConnection? Google { get; set; }

    [JsonPropertyName("instagram")]
    public PatreonUserV1SocialConnection? Instagram { get; set; }

    [JsonPropertyName("reddit")]
    public PatreonUserV1SocialConnection? Reddit { get; set; }

    [JsonPropertyName("spotify")]
    public PatreonUserV1SocialConnection? Spotify { get; set; }

    [JsonPropertyName("spotify_open_access")]
    public PatreonUserV1SocialConnection? SpotifyOpenAccess { get; set; }

    [JsonPropertyName("twitch")]
    public PatreonUserV1SocialConnection? Twitch { get; set; }

    [JsonPropertyName("twitter")]
    public PatreonUserV1SocialConnection? Twitter { get; set; }

    [JsonPropertyName("vimeo")]
    public PatreonUserV1SocialConnection? Vimeo { get; set; }

    [JsonPropertyName("youtube")]
    public PatreonUserV1SocialConnection? Youtube { get; set; }
}
