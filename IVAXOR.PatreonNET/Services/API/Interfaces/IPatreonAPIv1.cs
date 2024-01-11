using IVAXOR.PatreonNET.Models.Resources.CampaignsV1;
using IVAXOR.PatreonNET.Models.Resources.PledgeV1;
using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Models.Response;

namespace IVAXOR.PatreonNET.Services.API.Interfaces;

public interface IPatreonAPIv1
{
    public PatreonAPIv1Query<PatreonResponseSingle<PatreonUserV1Attributes, PatreonUserV1Relationships>, PatreonUserV1Attributes, PatreonUserV1Relationships> CurrentUser();

    public PatreonAPIv1Query<PatreonResponseMulti<PatreonCampaignV1Attributes, PatreonCampaignV1Relationships>, PatreonCampaignV1Attributes, PatreonCampaignV1Relationships> CurrentUserCampaigns();

    public PatreonAPIv1Query<PatreonResponseMulti<PatreonPledgeV1Attributes, PatreonPledgeV1Relationships>, PatreonPledgeV1Attributes, PatreonPledgeV1Relationships> CampaignPledges(int campaignId);
}
