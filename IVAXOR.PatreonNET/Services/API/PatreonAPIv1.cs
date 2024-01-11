using IVAXOR.PatreonNET.Models.Resources.CampaignsV1;
using IVAXOR.PatreonNET.Models.Resources.PledgeV1;
using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Models.Response;
using IVAXOR.PatreonNET.Services.API.Interfaces;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;
using System.Net.Http;

namespace IVAXOR.PatreonNET.Services.API;

public class PatreonAPIv1 : IPatreonAPIv1
{
    protected string Url { get; } = "https://patreon.com/api/oauth2/api";
    protected HttpClient HttpClient { get; }
    protected IPatreonTokenManager PatreonTokenManager { get; }

    public PatreonAPIv1(
        HttpClient httpClient,
        IPatreonTokenManager tokenManager)
    {
        HttpClient = httpClient;
        PatreonTokenManager = tokenManager;
    }

    public PatreonAPIv1Query<PatreonResponseSingle<PatreonUserV1Attributes, PatreonUserV1Relationships>, PatreonUserV1Attributes, PatreonUserV1Relationships> CurrentUser() =>
        new($"{Url}/current_user", HttpClient, PatreonTokenManager);

    public PatreonAPIv1Query<PatreonResponseMulti<PatreonCampaignV1Attributes, PatreonCampaignV1Relationships>, PatreonCampaignV1Attributes, PatreonCampaignV1Relationships> CurrentUserCampaigns() =>
        new($"{Url}/current_user/campaigns", HttpClient, PatreonTokenManager);

    public PatreonAPIv1Query<PatreonResponseMulti<PatreonPledgeV1Attributes, PatreonPledgeV1Relationships>, PatreonPledgeV1Attributes, PatreonPledgeV1Relationships> CampaignPledges(int campaignId) =>
        new($"{Url}/campaigns/{campaignId}/pledges", HttpClient, PatreonTokenManager);
}
