using IVAXOR.PatreonNET.Constants;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV1;
using IVAXOR.PatreonNET.Models.Resources.PledgeV1;
using IVAXOR.PatreonNET.Models.Resources.PostsV1;
using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using IVAXOR.PatreonNET.Services.API.Interfaces;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;
using System.Net.Http;
using System.Text.Json;

namespace IVAXOR.PatreonNET.Services.API;

public class PatreonAPIv1 : IPatreonAPIv1
{
    protected string Url { get; } = "https://patreon.com/api";
    protected HttpClient HttpClient { get; }
    protected IPatreonTokenManager TokenManager { get; }
    protected JsonSerializerOptions JsonSerializerOptions { get; } = PatreonJsonConstants.DefaultJsonSerializerOptions;

    public PatreonAPIv1(
        HttpClient httpClient,
        IPatreonTokenManager tokenManager)
    {
        HttpClient = httpClient;
        TokenManager = tokenManager;
    }

    public PatreonAPIv1(
        HttpClient httpClient,
        IPatreonTokenManager tokenManager,
        JsonSerializerOptions jsonSerializerOptions)
    {
        HttpClient = httpClient;
        TokenManager = tokenManager;
        JsonSerializerOptions = jsonSerializerOptions;
    }

    public PatreonAPIQuery<PatreonRawResponseSingle<PatreonUserV1Attributes, PatreonUserV1Relationships>, PatreonUserV1Attributes, PatreonUserV1Relationships> CurrentUser() =>
        new($"{Url}/oauth2/api/current_user", HttpClient, TokenManager, JsonSerializerOptions);

    public PatreonAPIQuery<PatreonRawResponseMulti<PatreonCampaignV1Attributes, PatreonCampaignV1Relationships>, PatreonCampaignV1Attributes, PatreonCampaignV1Relationships> CurrentUserCampaigns() =>
        new($"{Url}/oauth2/api/current_user/campaigns", HttpClient, TokenManager, JsonSerializerOptions);

    public PatreonAPIQuery<PatreonRawResponseMulti<PatreonPledgeV1Attributes, PatreonPledgeV1Relationships>, PatreonPledgeV1Attributes, PatreonPledgeV1Relationships> CampaignPledges(string campaignId) =>
        new($"{Url}/oauth2/api/campaigns/{campaignId}/pledges", HttpClient, TokenManager, JsonSerializerOptions);

    public PatreonAPIQuery<PatreonRawResponseMulti<PatreonPostV1Attributes, PatreonPostV1Relationships>, PatreonPostV1Attributes, PatreonPostV1Relationships> CampaignPosts(string campaignId) =>
        new($"{Url}/campaigns/{campaignId}/posts", HttpClient, TokenManager, JsonSerializerOptions);
}
