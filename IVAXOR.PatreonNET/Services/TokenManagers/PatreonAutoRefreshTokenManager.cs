using IVAXOR.PatreonNET.Exceptions;
using IVAXOR.PatreonNET.Models;
using IVAXOR.PatreonNET.Models.Configuration;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Timers;

namespace IVAXOR.PatreonNET.Services.TokenManagers
{
    public class PatreonAutoRefreshTokenManager : IPatreonTokenManager
    {
        public string AccessToken => PatreonClientTokens.AccessToken;

        protected PatreonClientTokens PatreonClientTokens { get; set; }

        protected readonly HttpClient HttpClient;
        protected readonly PatreonClient PatreonClient;
        protected readonly Timer Timer;

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
            var url = $"https://patreon.com/api/oauth2/token?" +
                $"grant_type=refresh_token&" +
                $"refresh_token={PatreonClientTokens.RefreshToken}&" +
                $"client_id={PatreonClient.ClientId}" +
                $"client_secret={PatreonClient.ClientSecret}";

            using var request = new HttpRequestMessage(HttpMethod.Post, url);

            using var response = await HttpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode) throw new RefreshTokenException();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            PatreonClientTokens = await JsonSerializer.DeserializeAsync<PatreonClientTokens>(responseStream);

            Timer.Interval = PatreonClientTokens.ExpiresIn - 300000;
            Timer.Start();
        }
    }
}
