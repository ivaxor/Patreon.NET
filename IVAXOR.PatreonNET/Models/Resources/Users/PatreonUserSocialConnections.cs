using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Users;

public class PatreonUserSocialConnections
{
    [JsonPropertyName("deviantart")]
    public PatreonUserSocialConnection? Deviantart { get; set; }

    [JsonPropertyName("discord")]
    public PatreonUserSocialConnection? Discord { get; set; }

    [JsonPropertyName("facebook")]
    public PatreonUserSocialConnection? Facebook { get; set; }

    [JsonPropertyName("google")]
    public PatreonUserSocialConnection? Google { get; set; }

    [JsonPropertyName("instagram")]
    public PatreonUserSocialConnection? Instagram { get; set; }

    [JsonPropertyName("reddit")]
    public PatreonUserSocialConnection? Reddit { get; set; }

    [JsonPropertyName("spotify")]
    public PatreonUserSocialConnection? Spotify { get; set; }

    [JsonPropertyName("spotify_open_access")]
    public PatreonUserSocialConnection? SpotifyOpenAccess { get; set; }

    [JsonPropertyName("twitch")]
    public PatreonUserSocialConnection? Twitch { get; set; }

    [JsonPropertyName("twitter")]
    public PatreonUserSocialConnection? Twitter { get; set; }

    [JsonPropertyName("vimeo")]
    public PatreonUserSocialConnection? Vimeo { get; set; }

    [JsonPropertyName("youtube")]
    public PatreonUserSocialConnection? Youtube { get; set; }
}
