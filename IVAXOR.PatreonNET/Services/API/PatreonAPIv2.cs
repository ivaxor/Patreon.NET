using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.PostsV2;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Resources.Webhooks;
using IVAXOR.PatreonNET.Models.Response;
using IVAXOR.PatreonNET.Services.API.Interfaces;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;
using System.Net.Http;

namespace IVAXOR.PatreonNET.Services.API;

public class PatreonAPIv2 : IPatreonAPIv2
{
    protected string Url { get; } = "https://patreon.com/api/oauth2/v2";

    protected HttpClient HttpClient { get; }
    protected IPatreonTokenManager PatreonTokenManager { get; }

    public PatreonAPIv2(
        HttpClient httpClient,
        IPatreonTokenManager tokenManager)
    {
        HttpClient = httpClient;
        PatreonTokenManager = tokenManager;
    }

    public PatreonAPIv2Query<PatreonResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> Identity() =>
        new($"{Url}/identity", HttpClient, PatreonTokenManager);

    public PatreonAPIv2Query<PatreonResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> Campaigns() =>
        new($"{Url}/campaigns", HttpClient, PatreonTokenManager);

    public PatreonAPIv2Query<PatreonResponseSingle<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> Campaign(int campaignId) =>
       new($"{Url}/campaigns/{campaignId}", HttpClient, PatreonTokenManager);

    public PatreonAPIv2Query<PatreonResponseMulti<PatreonMemberAttributes, PatreonMemberRelationships>, PatreonMemberAttributes, PatreonMemberRelationships> CampaignMembers(int campaignId) =>
        new($"{Url}/campaigns/{campaignId}/members", HttpClient, PatreonTokenManager);

    public PatreonAPIv2Query<PatreonResponseSingle<PatreonMemberAttributes, PatreonMemberRelationships>, PatreonMemberAttributes, PatreonMemberRelationships> Member(int memberId) =>
        new($"{Url}/members/{memberId}", HttpClient, PatreonTokenManager);

    public PatreonAPIv2Query<PatreonResponseMulti<PatreonPostV2Attributes, PatreonPostV2Relationships>, PatreonPostV2Attributes, PatreonPostV2Relationships> CampaignPosts(int campaignId) =>
        new($"{Url}/campaigns/{campaignId}/posts", HttpClient, PatreonTokenManager);

    public PatreonAPIv2Query<PatreonResponseSingle<PatreonPostV2Attributes, PatreonPostV2Relationships>, PatreonPostV2Attributes, PatreonPostV2Relationships> Post(int postId) =>
        new($"{Url}/posts/{postId}", HttpClient, PatreonTokenManager);

    public PatreonAPIv2Query<PatreonResponseMulti<PatreonWebhookAttributes, PatreonWebhookRelationships>, PatreonWebhookAttributes, PatreonWebhookRelationships> Webhooks() =>
        new($"{Url}/webhooks", HttpClient, PatreonTokenManager);
}
