using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.PostsV2;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Resources.Webhooks;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using IVAXOR.PatreonNET.Services.API.Interfaces;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Services.API;

public class PatreonAPIv2 : IPatreonAPIv2
{
    protected string Url { get; } = "https://patreon.com/api/oauth2/v2";

    protected HttpClient HttpClient { get; }
    protected IPatreonTokenManager TokenManager { get; }
    protected JsonSerializerOptions JsonSerializerOptions { get; }

    public PatreonAPIv2(
        HttpClient httpClient,
        IPatreonTokenManager tokenManager)
    {
        HttpClient = httpClient;
        TokenManager = tokenManager;
        JsonSerializerOptions = new()
        {
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
        };
    }

    public PatreonAPIv2(
        HttpClient httpClient,
        IPatreonTokenManager tokenManager,
        JsonSerializerOptions jsonSerializerOptions)
    {
        HttpClient = httpClient;
        TokenManager = tokenManager;
        JsonSerializerOptions = jsonSerializerOptions;
    }

    public PatreonAPIv2Query<PatreonRawResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> Identity() =>
        new($"{Url}/identity", HttpClient, TokenManager, JsonSerializerOptions);

    public PatreonAPIv2Query<PatreonRawResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> Campaigns() =>
        new($"{Url}/campaigns", HttpClient, TokenManager, JsonSerializerOptions);

    public PatreonAPIv2Query<PatreonRawResponseSingle<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> Campaign(int campaignId) =>
       new($"{Url}/campaigns/{campaignId}", HttpClient, TokenManager, JsonSerializerOptions);

    public PatreonAPIv2Query<PatreonRawResponseMulti<PatreonMemberAttributes, PatreonMemberRelationships>, PatreonMemberAttributes, PatreonMemberRelationships> CampaignMembers(int campaignId) =>
        new($"{Url}/campaigns/{campaignId}/members", HttpClient, TokenManager, JsonSerializerOptions);

    public PatreonAPIv2Query<PatreonRawResponseSingle<PatreonMemberAttributes, PatreonMemberRelationships>, PatreonMemberAttributes, PatreonMemberRelationships> Member(string memberId) =>
        new($"{Url}/members/{memberId}", HttpClient, TokenManager, JsonSerializerOptions);

    public PatreonAPIv2Query<PatreonRawResponseMulti<PatreonPostV2Attributes, PatreonPostV2Relationships>, PatreonPostV2Attributes, PatreonPostV2Relationships> CampaignPosts(int campaignId) =>
        new($"{Url}/campaigns/{campaignId}/posts", HttpClient, TokenManager, JsonSerializerOptions);

    public PatreonAPIv2Query<PatreonRawResponseSingle<PatreonPostV2Attributes, PatreonPostV2Relationships>, PatreonPostV2Attributes, PatreonPostV2Relationships> Post(int postId) =>
        new($"{Url}/posts/{postId}", HttpClient, TokenManager, JsonSerializerOptions);

    public PatreonAPIv2Query<PatreonRawResponseMulti<PatreonWebhookAttributes, PatreonWebhookRelationships>, PatreonWebhookAttributes, PatreonWebhookRelationships> Webhooks() =>
        new($"{Url}/webhooks", HttpClient, TokenManager, JsonSerializerOptions);
}
