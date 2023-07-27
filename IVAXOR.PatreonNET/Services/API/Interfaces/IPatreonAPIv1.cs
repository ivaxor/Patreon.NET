using IVAXOR.PatreonNET.Models.Campaigns;
using IVAXOR.PatreonNET.Models.Pledges;
using IVAXOR.PatreonNET.Models.Response;
using IVAXOR.PatreonNET.Models.Users;

namespace IVAXOR.PatreonNET.Services.API.Interfaces
{
    public interface IPatreonAPIv1
    {
        public PatreonAPIv1Query<PatreonResponseSingle<PatreonUserAttributes, PatreonUserRelationships>, PatreonUserAttributes, PatreonUserRelationships> CurrentUser();

        public PatreonAPIv1Query<PatreonResponseMulti<PatreonCampaignAttributes, PatreonCampaignRelationships>, PatreonCampaignAttributes, PatreonCampaignRelationships> CurrentUserCampaigns();

        public PatreonAPIv1Query<PatreonResponseMulti<PatreonPledgeEventAttributes, PatreonPledgeEventRelationships>, PatreonPledgeEventAttributes, PatreonPledgeEventRelationships> CampaignPledges(string campaignId);
    }
}
