using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.PostsV2;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Resources.Webhooks;
using IVAXOR.PatreonNET.Models.Responses.Raw;

namespace IVAXOR.PatreonNET.Services.API.Interfaces;

public interface IPatreonAPIv2
{
    public PatreonAPIQuery<PatreonRawResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> Identity();

    public PatreonAPIQuery<PatreonRawResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> Campaigns();

    public PatreonAPIQuery<PatreonRawResponseSingle<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> Campaign(string campaignId);

    public PatreonAPIQuery<PatreonRawResponseMulti<PatreonMemberAttributes, PatreonMemberRelationships>, PatreonMemberAttributes, PatreonMemberRelationships> CampaignMembers(string campaignId);

    public PatreonAPIQuery<PatreonRawResponseSingle<PatreonMemberAttributes, PatreonMemberRelationships>, PatreonMemberAttributes, PatreonMemberRelationships> Member(string memberId);

    public PatreonAPIQuery<PatreonRawResponseMulti<PatreonPostV2Attributes, PatreonPostV2Relationships>, PatreonPostV2Attributes, PatreonPostV2Relationships> CampaignPosts(string campaignId);

    public PatreonAPIQuery<PatreonRawResponseSingle<PatreonPostV2Attributes, PatreonPostV2Relationships>, PatreonPostV2Attributes, PatreonPostV2Relationships> Post(string postId);

    public PatreonAPIQuery<PatreonRawResponseMulti<PatreonWebhookAttributes, PatreonWebhookRelationships>, PatreonWebhookAttributes, PatreonWebhookRelationships> Webhooks();
}
