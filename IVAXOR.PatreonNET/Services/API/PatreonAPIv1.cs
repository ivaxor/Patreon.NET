using IVAXOR.PatreonNET.Models.Campaigns;
using IVAXOR.PatreonNET.Models.Pledges;
using IVAXOR.PatreonNET.Models.Response;
using IVAXOR.PatreonNET.Models.Users;
using IVAXOR.PatreonNET.Services.API.Interfaces;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;
using System.Net.Http;

namespace IVAXOR.PatreonNET.Services.API
{
    public class PatreonAPIv1 : IPatreonAPIv1
    {
        protected readonly HttpClient HttpClient;
        protected readonly IPatreonTokenManager PatreonTokenManager;

        public PatreonAPIv1(
            HttpClient httpClient,
            IPatreonTokenManager tokenManager)
        {
            HttpClient = httpClient;
            PatreonTokenManager = tokenManager;
        }

        public PatreonAPIv1Query<PatreonResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> CurrentUser() =>
            new PatreonAPIv1Query<PatreonResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships>(
                "https://patreon.com/api/oauth2/api/current_user",
                HttpClient,
                PatreonTokenManager);

        public PatreonAPIv1Query<PatreonResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> CurrentUserCampaigns() =>
            new PatreonAPIv1Query<PatreonResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>(
                "https://patreon.com/api/oauth2/api/current_user/campaigns",
                HttpClient,
                PatreonTokenManager);

        public PatreonAPIv1Query<PatreonResponseMulti<PatreonPledgeEventAttributes, PatreonPledgeEventRelationships>, PatreonPledgeEventAttributes, PatreonPledgeEventRelationships> CampaignPledges(string campaignId) =>
            new PatreonAPIv1Query<PatreonResponseMulti<PatreonPledgeEventAttributes, PatreonPledgeEventRelationships>, PatreonPledgeEventAttributes, PatreonPledgeEventRelationships>(
                $"https://patreon.com/api/oauth2/api/campaigns/{campaignId}/pledges",
                HttpClient,
                PatreonTokenManager);
    }
}
