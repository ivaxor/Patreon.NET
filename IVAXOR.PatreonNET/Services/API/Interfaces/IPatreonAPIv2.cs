using IVAXOR.PatreonNET.Models.Campaigns;
using IVAXOR.PatreonNET.Models.Posts;
using IVAXOR.PatreonNET.Models.Response;
using IVAXOR.PatreonNET.Models.Users;
using IVAXOR.PatreonNET.Models.Webhooks;

namespace IVAXOR.PatreonNET.Services.API.Interfaces
{
    public interface IPatreonAPIv2
    {
        public PatreonAPIv2Query<PatreonResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> Identity();

        public PatreonAPIv2Query<PatreonResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> Campaigns();

        public PatreonAPIv2Query<PatreonResponseSingle<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>, PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> Campaign(string campaignId);

        /*
        public PatreonAPIv2Query<PatreonResponseMulti<object, object>, object, object> CampaignMembers(string campaignId);

        public PatreonAPIv2Query<PatreonResponseSingle<object, object>, object, object> CampaignMembers(string memberId);
        */

        public PatreonAPIv2Query<PatreonResponseMulti<PatreonPostV2Attributes, PatreonPostV2Relationships>, PatreonPostV2Attributes, PatreonPostV2Relationships> CampaignPosts(string campaignId);

        public PatreonAPIv2Query<PatreonResponseSingle<PatreonPostV2Attributes, PatreonPostV2Relationships>, PatreonPostV2Attributes, PatreonPostV2Relationships> Post(string postId);

        public PatreonAPIv2Query<PatreonResponseMulti<PatreonWebhookAttributes, PatreonWebhookRelationships>, PatreonWebhookAttributes, PatreonWebhookRelationships> Webhooks();
    }
}
