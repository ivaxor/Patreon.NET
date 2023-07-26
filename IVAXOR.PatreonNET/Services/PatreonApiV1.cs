using IVAXOR.PatreonNET.Constants;
using IVAXOR.PatreonNET.Exceptions;
using IVAXOR.PatreonNET.Models;
using IVAXOR.PatreonNET.Models.Responses;
using IVAXOR.PatreonNET.Services.Interfaces;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace IVAXOR.PatreonNET.Services
{
    public class PatreonApiV1
    {
        private readonly HttpClient HttpClient;
        private readonly IPatreonTokenManager PatreonTokenManager;

        public PatreonApiV1(
            HttpClient httpClient,
            IPatreonTokenManager tokenManager)
        {
            HttpClient = httpClient;
            PatreonTokenManager = tokenManager;
        }

        public async ValueTask<PatreonResponseSingle<PatreonUserV2Attributes, PatreonCampaignV2Relationships>> GetCurrentUserAsync(CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, "https://www.patreon.com/api/oauth2/api/current_user");
            request.Headers.Add("Authorization", $"Bearer {PatreonTokenManager.AccessToken}");

            using var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode) throw new HttpRequestException();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<PatreonResponseSingle<PatreonUserV2Attributes, PatreonCampaignV2Relationships>>(responseStream, cancellationToken: cancellationToken);

        }

        public async ValueTask<PatreonResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>> GetCurrentUserCampaignsAsync(
            string[] includes = null,
            CancellationToken cancellationToken = default)
        {
            if (includes?.All(_ => AvailableIncludes.V1CurrentUsercampaigns.Contains(_)) ?? false) throw new InvalidIncludeException();

            var url = "https://www.patreon.com/api/oauth2/api/current_user/campaigns";
            if (includes?.Any() ?? false) url += $"?includes={string.Join(',', includes)}";

            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", $"Bearer {PatreonTokenManager.AccessToken}");

            using var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode) throw new HttpRequestException();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var rs = await response.Content.ReadAsStringAsync();

            return await JsonSerializer.DeserializeAsync<PatreonResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>>(responseStream, cancellationToken: cancellationToken);
        }
    }
}