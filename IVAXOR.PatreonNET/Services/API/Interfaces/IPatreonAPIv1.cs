using IVAXOR.PatreonNET.Models.Resources.CampaignsV1;
using IVAXOR.PatreonNET.Models.Resources.PledgeV1;
using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Models.Responses.Raw;

namespace IVAXOR.PatreonNET.Services.API.Interfaces;

public interface IPatreonAPIv1
{
    public PatreonAPIQuery<PatreonRawResponseSingle<PatreonUserV1Attributes, PatreonUserV1Relationships>, PatreonUserV1Attributes, PatreonUserV1Relationships> CurrentUser();

    public PatreonAPIQuery<PatreonRawResponseMulti<PatreonCampaignV1Attributes, PatreonCampaignV1Relationships>, PatreonCampaignV1Attributes, PatreonCampaignV1Relationships> CurrentUserCampaigns();

    public PatreonAPIQuery<PatreonRawResponseMulti<PatreonPledgeV1Attributes, PatreonPledgeV1Relationships>, PatreonPledgeV1Attributes, PatreonPledgeV1Relationships> CampaignPledges(string campaignId);
}
