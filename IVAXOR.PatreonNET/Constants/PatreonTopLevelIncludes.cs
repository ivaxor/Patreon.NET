namespace IVAXOR.PatreonNET.Constants;

public static class PatreonTopLevelIncludes
{
    public static class V1
    {
        public static class CurrentUser
        {
            public static readonly string Campaign = "campaign";
            public static readonly string Pledges = "pledges";
        }

        public static class CurrentUserCampaigns
        {
            public static readonly string Creator = "creator";
            public static readonly string Goals = "goals";
            public static readonly string Rewards = "rewards";
            public static readonly string Pledges = "pledges";
        }

        public static class CampaignPledges
        {
            public static readonly string Address = "address";
            public static readonly string Creator = "creator";
            public static readonly string Patron = "patron";
            public static readonly string Reward = "reward";
        }

        public static class CampaignPosts
        {
            public static readonly string Attachments = "attachments";
            public static readonly string Campaign = "campaign";
            public static readonly string ContentLocks = "content_locks";
            public static readonly string Comments = "comments";
            public static readonly string Likes = "likes";
            public static readonly string User = "user";
            public static readonly string UserDefinedTags = "user_defined_tags";
        }
    }

    public static class V2
    {
        public static class Identity
        {
            /// <summary>
            /// If you request memberships and don't have the identity.memberships scope, you will receive data about the user’s membership to your campaign.
            /// If you do have the scope, you will receive data about all of the user’s memberships, to all the campaigns they’re members of.
            /// If you request Campaign and memberships, you will receive information about the user’s memberships and the Campaigns they are Member of, provided you have the campaigns and identity.memberships scopes.
            /// </summary>
            public static readonly string Memberships = "memberships";

            /// <summary>
            /// If you request Campaign and have the campaigns scope, you will receive information about the user’s Campaign.
            /// If you request Campaign and memberships, you will receive information about the user’s memberships and the Campaigns they are Member of, provided you have the campaigns and identity.memberships scopes.
            /// </summary>
            public static readonly string Campaign = "campaign";
        }

        public static class Campaigns
        {
            public static readonly string Benefits = "benefits";
            public static readonly string BenefitsDeliverables = "benefits.deliverables";

            public static readonly string Categories = "categories";
            public static readonly string Creator = "creator";

            public static readonly string Tiers = "tiers";
            public static readonly string TiersBenefits = "tiers.benefits";
            public static readonly string TiersImage = "tiers.tier_image";

            public static readonly string Goals = "goals";
        }

        public static class CampaignPosts
        {
            public static readonly string Campaign = "campaign";
            public static readonly string User = "user";
        }

        public static class Members
        {
            public static readonly string Address = "address";
            public static readonly string Campaign = "campaign";
            public static readonly string CurrentlyEntitledTiers = "currently_entitled_tiers";
            public static readonly string User = "user";
        }

        public static class Webhooks
        {
            public static readonly string Client = "client";
            public static readonly string Campaign = "campaign";
        }
    }
}
