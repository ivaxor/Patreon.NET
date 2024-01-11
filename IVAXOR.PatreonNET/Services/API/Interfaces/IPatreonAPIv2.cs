using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.PostsV2;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Resources.Webhooks;
using IVAXOR.PatreonNET.Models.Response;

namespace IVAXOR.PatreonNET.Services.API.Interfaces;

public interface IPatreonAPIv2
{
    public PatreonAPIv2Query<PatreonResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> Identity();

    public PatreonAPIv2Query<PatreonResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> Campaigns();

    public PatreonAPIv2Query<PatreonResponseSingle<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> Campaign(int campaignId);

    public PatreonAPIv2Query<PatreonResponseMulti<PatreonMemberAttributes, PatreonMemberRelationships>, PatreonMemberAttributes, PatreonMemberRelationships> CampaignMembers(int campaignId);

    public PatreonAPIv2Query<PatreonResponseSingle<PatreonMemberAttributes, PatreonMemberRelationships>, PatreonMemberAttributes, PatreonMemberRelationships> Member(int memberId);

    public PatreonAPIv2Query<PatreonResponseMulti<PatreonPostV2Attributes, PatreonPostV2Relationships>, PatreonPostV2Attributes, PatreonPostV2Relationships> CampaignPosts(int campaignId);

    public PatreonAPIv2Query<PatreonResponseSingle<PatreonPostV2Attributes, PatreonPostV2Relationships>, PatreonPostV2Attributes, PatreonPostV2Relationships> Post(int postId);

    public PatreonAPIv2Query<PatreonResponseMulti<PatreonWebhookAttributes, PatreonWebhookRelationships>, PatreonWebhookAttributes, PatreonWebhookRelationships> Webhooks();
}
