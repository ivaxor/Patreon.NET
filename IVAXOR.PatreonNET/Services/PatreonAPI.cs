using IVAXOR.PatreonNET.Models;
using IVAXOR.PatreonNET.Services.Interfaces;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace IVAXOR.PatreonNET.Services
{
    public class PatreonAPI
    {
        private readonly HttpClient HttpClient;
        private readonly IPatreonTokenManager PatreonTokenManager;

        public PatreonAPI(
            HttpClient httpClient,
            IPatreonTokenManager tokenManager)
        {
            HttpClient = httpClient;
            PatreonTokenManager = tokenManager;
        }

        public async ValueTask<PatreonResponse<PatreonUserV2Attributes>> GetUserAsync(CancellationToken cancellationToken = default)
        {
            var url = "https://www.patreon.com/api/oauth2/v2/identity";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", $"Bearer {PatreonTokenManager.AccessToken}");

            var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode) throw new HttpRequestException();

            var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<PatreonResponse<PatreonUserV2Attributes>>(responseStream, cancellationToken: cancellationToken);
        }
    }
}