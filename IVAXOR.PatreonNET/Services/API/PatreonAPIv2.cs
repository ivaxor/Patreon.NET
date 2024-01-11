using IVAXOR.PatreonNET.Models.Campaigns;
using IVAXOR.PatreonNET.Models.Posts;
using IVAXOR.PatreonNET.Models.Response;
using IVAXOR.PatreonNET.Models.UsersV2;
using IVAXOR.PatreonNET.Models.Webhooks;
using IVAXOR.PatreonNET.Services.API.Interfaces;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;
using System.Net.Http;

namespace IVAXOR.PatreonNET.Services.API;

public class PatreonAPIv2 : IPatreonAPIv2
{
    protected readonly HttpClient HttpClient;
    protected readonly IPatreonTokenManager PatreonTokenManager;

    public PatreonAPIv2(
        HttpClient httpClient,
        IPatreonTokenManager tokenManager)
    {
        HttpClient = httpClient;
        PatreonTokenManager = tokenManager;
    }

    public PatreonAPIv2Query<PatreonResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> Identity() =>
        new PatreonAPIv2Query<PatreonResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships>(
            "https://patreon.com/api/oauth2/v2/identity",
            HttpClient,
            PatreonTokenManager);

    public PatreonAPIv2Query<PatreonResponseMulti<PatreonCampaignAttributes, PatreonCampaignRelationships>, PatreonCampaignAttributes, PatreonCampaignRelationships> Campaigns() =>
        new PatreonAPIv2Query<PatreonResponseMulti<PatreonCampaignAttributes, PatreonCampaignRelationships>, PatreonCampaignAttributes, PatreonCampaignRelationships>(
            "https://patreon.com/api/oauth2/v2/campaigns",
            HttpClient,
            PatreonTokenManager);

    public PatreonAPIv2Query<PatreonResponseSingle<PatreonCampaignAttributes, PatreonCampaignRelationships>, PatreonCampaignAttributes, PatreonCampaignRelationships> Campaign(string campaignId) =>
       new PatreonAPIv2Query<PatreonResponseSingle<PatreonCampaignAttributes, PatreonCampaignRelationships>, PatreonCampaignAttributes, PatreonCampaignRelationships>(
           $"https://patreon.com/api/oauth2/v2/campaigns/{campaignId}",
           HttpClient,
           PatreonTokenManager);

    /*
    public PatreonAPIv2Query<PatreonResponseMulti<object, object>, object, object> CampaignMembers(string campaignId) =>
        new PatreonAPIv2Query<PatreonResponseMulti<object, object>, object, object>(
            $"https://patreon.com/api/oauth2/v2/campaigns/{campaignId}/members",
            HttpClient,
            PatreonTokenManager);

    public PatreonAPIv2Query<PatreonResponseSingle<object, object>, object, object> CampaignMembers(string memberId) =>
        new PatreonAPIv2Query<PatreonResponseSingle<object, object>, object, object>(
            $"https://patreon.com/api/oauth2/v2/members/{memberId}",
            HttpClient,
            PatreonTokenManager);
    */

    public PatreonAPIv2Query<PatreonResponseMulti<PatreonPostAttributes, PatreonPostRelationships>, PatreonPostAttributes, PatreonPostRelationships> CampaignPosts(string campaignId) =>
        new PatreonAPIv2Query<PatreonResponseMulti<PatreonPostAttributes, PatreonPostRelationships>, PatreonPostAttributes, PatreonPostRelationships>(
            $"https://patreon.com/api/oauth2/v2/campaigns/{campaignId}/posts",
            HttpClient,
            PatreonTokenManager);

    public PatreonAPIv2Query<PatreonResponseSingle<PatreonPostAttributes, PatreonPostRelationships>, PatreonPostAttributes, PatreonPostRelationships> Post(string postId) =>
        new PatreonAPIv2Query<PatreonResponseSingle<PatreonPostAttributes, PatreonPostRelationships>, PatreonPostAttributes, PatreonPostRelationships>(
            $"https://patreon.com/api/oauth2/v2/posts/{postId}",
            HttpClient,
            PatreonTokenManager);

    public PatreonAPIv2Query<PatreonResponseMulti<PatreonWebhookAttributes, PatreonWebhookRelationships>, PatreonWebhookAttributes, PatreonWebhookRelationships> Webhooks() =>
        new PatreonAPIv2Query<PatreonResponseMulti<PatreonWebhookAttributes, PatreonWebhookRelationships>, PatreonWebhookAttributes, PatreonWebhookRelationships>(
            $"https://patreon.com/api/oauth2/v2/webhooks",
            HttpClient,
            PatreonTokenManager);
}
