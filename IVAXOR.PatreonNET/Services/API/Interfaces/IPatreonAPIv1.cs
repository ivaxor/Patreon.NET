using IVAXOR.PatreonNET.Models.Campaigns;
using IVAXOR.PatreonNET.Models.Pledges;
using IVAXOR.PatreonNET.Models.Response;
using IVAXOR.PatreonNET.Models.UsersV1;

namespace IVAXOR.PatreonNET.Services.API.Interfaces;

public interface IPatreonAPIv1
{
    public PatreonAPIv1Query<PatreonResponseSingle<PatreonUserV1Attributes, PatreonUserV1Relationships>, PatreonUserV1Attributes, PatreonUserV1Relationships> CurrentUser();

    public PatreonAPIv1Query<PatreonResponseMulti<PatreonCampaignAttributes, PatreonCampaignRelationships>, PatreonCampaignAttributes, PatreonCampaignRelationships> CurrentUserCampaigns();

    public PatreonAPIv1Query<PatreonResponseMulti<PatreonPledgeEventAttributes, PatreonPledgeEventRelationships>, PatreonPledgeEventAttributes, PatreonPledgeEventRelationships> CampaignPledges(string campaignId);
}
