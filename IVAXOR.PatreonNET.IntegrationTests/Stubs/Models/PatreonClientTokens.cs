namespace IVAXOR.PatreonNET.IntegrationTests.Stubs.Models;

public class PatreonClientTokens
{
    [JsonRequired]
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonRequired]
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonRequired]
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonRequired]
    [JsonPropertyName("scope")]
    public string Scopes { get; set; }
}
