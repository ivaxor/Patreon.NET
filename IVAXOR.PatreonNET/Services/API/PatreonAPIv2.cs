using IVAXOR.PatreonNET.Models.Campaigns;
using IVAXOR.PatreonNET.Models.Posts;
using IVAXOR.PatreonNET.Models.Response;
using IVAXOR.PatreonNET.Models.Users;
using IVAXOR.PatreonNET.Models.Webhooks;
using IVAXOR.PatreonNET.Services.API.Interfaces;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;
using System.Net.Http;

namespace IVAXOR.PatreonNET.Services.API
{
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
                "https://www.patreon.com/api/oauth2/v2/identity",
                HttpClient,
                PatreonTokenManager);

        public PatreonAPIv2Query<PatreonResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> Campaigns() =>
            new PatreonAPIv2Query<PatreonResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>(
                "https://www.patreon.com/api/oauth2/v2/campaigns",
                HttpClient,
                PatreonTokenManager);

        public PatreonAPIv2Query<PatreonResponseSingle<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> Campaign(string campaignId) =>
           new PatreonAPIv2Query<PatreonResponseSingle<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>(
               $"https://www.patreon.com/api/oauth2/v2/campaigns/{campaignId}",
               HttpClient,
               PatreonTokenManager);

        /*
        public PatreonAPIv2Query<PatreonResponseMulti<object, object>, object, object> CampaignMembers(string campaignId) =>
            new PatreonAPIv2Query<PatreonResponseMulti<object, object>, object, object>(
                $"https://www.patreon.com/api/oauth2/v2/campaigns/{campaignId}/members",
                HttpClient,
                PatreonTokenManager);

        public PatreonAPIv2Query<PatreonResponseSingle<object, object>, object, object> CampaignMembers(string memberId) =>
            new PatreonAPIv2Query<PatreonResponseSingle<object, object>, object, object>(
                $"https://www.patreon.com/api/oauth2/v2/members/{memberId}",
                HttpClient,
                PatreonTokenManager);
        */

        public PatreonAPIv2Query<PatreonResponseMulti<PatreonPostV2Attributes, PatreonPostV2Relationships>, PatreonPostV2Attributes, PatreonPostV2Relationships> CampaignPosts(string campaignId) =>
            new PatreonAPIv2Query<PatreonResponseMulti<PatreonPostV2Attributes, PatreonPostV2Relationships>, PatreonPostV2Attributes, PatreonPostV2Relationships>(
                $"https://www.patreon.com/api/oauth2/v2/campaigns/{campaignId}/posts",
                HttpClient,
                PatreonTokenManager);

        public PatreonAPIv2Query<PatreonResponseSingle<PatreonPostV2Attributes, PatreonPostV2Relationships>, PatreonPostV2Attributes, PatreonPostV2Relationships> Post(string postId) =>
            new PatreonAPIv2Query<PatreonResponseSingle<PatreonPostV2Attributes, PatreonPostV2Relationships>, PatreonPostV2Attributes, PatreonPostV2Relationships>(
                $"https://www.patreon.com/api/oauth2/v2/posts/{postId}",
                HttpClient,
                PatreonTokenManager);

        public PatreonAPIv2Query<PatreonResponseMulti<PatreonWebhookAttributes, PatreonWebhookRelationships>, PatreonWebhookAttributes, PatreonWebhookRelationships> Webhooks() =>
            new PatreonAPIv2Query<PatreonResponseMulti<PatreonWebhookAttributes, PatreonWebhookRelationships>, PatreonWebhookAttributes, PatreonWebhookRelationships>(
                $"https://patreon.com/api/oauth2/v2/webhooks",
                HttpClient,
                PatreonTokenManager);
    }
}
