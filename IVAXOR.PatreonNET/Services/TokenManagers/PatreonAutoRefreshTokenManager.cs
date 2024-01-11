using IVAXOR.PatreonNET.Exceptions;
using IVAXOR.PatreonNET.Models;
using IVAXOR.PatreonNET.Models.Configuration;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Timers;
using System.Web;

namespace IVAXOR.PatreonNET.Services.TokenManagers;

public class PatreonAutoRefreshTokenManager : IPatreonTokenManager
{
    public string AccessToken => PatreonClientTokens.AccessToken;

    protected PatreonClientTokens PatreonClientTokens { get; private set; }

    protected HttpClient HttpClient { get; }
    protected PatreonClient PatreonClient { get; }
    protected Timer Timer { get; }

    public PatreonAutoRefreshTokenManager(
        HttpClient httpClient,
        PatreonClient client,
        PatreonClientTokens tokens)
    {
        HttpClient = httpClient;
        PatreonClient = client;
        PatreonClientTokens = tokens;

        Timer = new Timer();
        Timer.Interval = PatreonClientTokens.ExpiresIn - TimeSpan.FromMinutes(1).TotalMilliseconds;
        Timer.AutoReset = false;
        Timer.Elapsed += OnTimerElapsed;
        Timer.Start();
    }

    protected async void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        var queryParams = HttpUtility.ParseQueryString(string.Empty);
        queryParams.Add("grant_type", "refresh_token");
        queryParams.Add("refresh_token", PatreonClientTokens.RefreshToken);
        queryParams.Add("client_id", PatreonClient.ClientId);
        queryParams.Add("client_secret", PatreonClient.ClientSecret);
        var query = queryParams.ToString();
        var decodedQuery = HttpUtility.HtmlDecode(query);

        var urlBuilder = new UriBuilder("https://patreon.com/api/oauth2/token");
        urlBuilder.Query = decodedQuery;
        var url = urlBuilder.ToString();

        using var request = new HttpRequestMessage(HttpMethod.Post, url);

        using var response = await HttpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode) throw new RefreshTokenException();

        using var responseStream = await response.Content.ReadAsStreamAsync();
        PatreonClientTokens = await JsonSerializer.DeserializeAsync<PatreonClientTokens>(responseStream);

        Timer.Interval = PatreonClientTokens.ExpiresIn - 300000;
        Timer.Start();
    }
}
