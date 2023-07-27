using IVAXOR.PatreonNET.Models.Campaigns;
using IVAXOR.PatreonNET.Models.Pledges;
using IVAXOR.PatreonNET.Models.Response;
using IVAXOR.PatreonNET.Models.Users;

namespace IVAXOR.PatreonNET.Services.API.Interfaces
{
    public interface IPatreonAPIv1
    {
        public PatreonAPIv1Query<PatreonResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> CurrentUser();

        public PatreonAPIv1Query<PatreonResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> CurrentUserCampaigns();

        public PatreonAPIv1Query<PatreonResponseMulti<PatreonPledgeEventAttributes, PatreonPledgeEventRelationships>, PatreonPledgeEventAttributes, PatreonPledgeEventRelationships> CampaignPledges(string campaignId);
    }
}
