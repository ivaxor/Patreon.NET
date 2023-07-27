using IVAXOR.PatreonNET.Constants;
using IVAXOR.PatreonNET.Exceptions;
using IVAXOR.PatreonNET.Models.Campaigns;
using IVAXOR.PatreonNET.Models.Pledges;
using IVAXOR.PatreonNET.Models.Response;
using IVAXOR.PatreonNET.Models.Users;
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
        protected readonly HttpClient HttpClient;
        protected readonly IPatreonTokenManager PatreonTokenManager;

        public PatreonApiV1(
            HttpClient httpClient,
            IPatreonTokenManager tokenManager)
        {
            HttpClient = httpClient;
            PatreonTokenManager = tokenManager;
        }

        public async ValueTask<PatreonResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>> GetCurrentUserAsync(CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, "https://www.patreon.com/api/oauth2/api/current_user");
            request.Headers.Add("Authorization", $"Bearer {PatreonTokenManager.AccessToken}");

            using var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode) throw new HttpRequestException();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<PatreonResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>>(responseStream, Json.SerializerOptions, cancellationToken);

        }

        public async ValueTask<PatreonResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>> GetCurrentUserCampaignsAsync(
            string[] includes = null,
            CancellationToken cancellationToken = default)
        {
            if (!includes?.All(_ => AvailableIncludes.V1CurrentUsercampaigns.Contains(_)) ?? false) throw new InvalidIncludeException();

            var url = "https://www.patreon.com/api/oauth2/api/current_user/campaigns";
            if (includes?.Any() ?? false) url += $"?includes={string.Join(',', includes)}";

            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", $"Bearer {PatreonTokenManager.AccessToken}");

            using var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode) throw new HttpRequestException();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<PatreonResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>>(responseStream, Json.SerializerOptions, cancellationToken);
        }

        public async ValueTask<PatreonResponseMulti<PatreonPledgeEventAttributes, PatreonPledgeEventRelationships>> GetCampaignPledgesAsync(
            string campaignId,
            CancellationToken cancellationToken = default)
        {
            var url = $"https://patreon.com/api/oauth2/api/campaigns/{campaignId}/pledges";

            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", $"Bearer {PatreonTokenManager.AccessToken}");

            using var response = await HttpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode) throw new HttpRequestException();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<PatreonResponseMulti<PatreonPledgeEventAttributes, PatreonPledgeEventRelationships>>(responseStream, Json.SerializerOptions, cancellationToken);
        }
    }
}