using IVAXOR.PatreonNET.Models.Campaigns;
using IVAXOR.PatreonNET.Models.Posts;
using IVAXOR.PatreonNET.Models.Response;
using IVAXOR.PatreonNET.Models.Users;
using IVAXOR.PatreonNET.Models.Webhooks;

namespace IVAXOR.PatreonNET.Services.API.Interfaces
{
    public interface IPatreonAPIv2
    {
        public PatreonAPIv2Query<PatreonResponseSingle<PatreonUserAttributes, PatreonUserRelationships>, PatreonUserAttributes, PatreonUserRelationships> Identity();

        public PatreonAPIv2Query<PatreonResponseMulti<PatreonCampaignAttributes, PatreonCampaignRelationships>, PatreonCampaignAttributes, PatreonCampaignRelationships> Campaigns();

        public PatreonAPIv2Query<PatreonResponseSingle<PatreonCampaignAttributes, PatreonCampaignRelationships>, PatreonCampaignAttributes, PatreonCampaignRelationships> Campaign(string campaignId);

        /*
        public PatreonAPIv2Query<PatreonResponseMulti<object, object>, object, object> CampaignMembers(string campaignId);

        public PatreonAPIv2Query<PatreonResponseSingle<object, object>, object, object> CampaignMembers(string memberId);
        */

        public PatreonAPIv2Query<PatreonResponseMulti<PatreonPostAttributes, PatreonPostRelationships>, PatreonPostAttributes, PatreonPostRelationships> CampaignPosts(string campaignId);

        public PatreonAPIv2Query<PatreonResponseSingle<PatreonPostAttributes, PatreonPostRelationships>, PatreonPostAttributes, PatreonPostRelationships> Post(string postId);

        public PatreonAPIv2Query<PatreonResponseMulti<PatreonWebhookAttributes, PatreonWebhookRelationships>, PatreonWebhookAttributes, PatreonWebhookRelationships> Webhooks();
    }
}
