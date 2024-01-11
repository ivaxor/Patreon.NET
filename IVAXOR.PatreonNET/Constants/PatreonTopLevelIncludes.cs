namespace IVAXOR.PatreonNET.Constants;

public static class PatreonTopLevelIncludes
{
    public static class V1
    {
        public static class CurrentUserCampaigns
        {
            public static readonly string Rewards = "rewards";
            public static readonly string Creator = "creator";
            public static readonly string Goals = "goals";
            public static readonly string Pledges = "pledges";
        }
    }

    public static class V2
    {
        public static class Identity
        {
            public static readonly string Memberships = "memberships";
            public static readonly string Campaign = "campaign";
        }

        public static class Campaigns
        {
            public static readonly string Tiers = "tiers";
            public static readonly string Creator = "creator";
            public static readonly string Benefits = "benefits";
            public static readonly string Goals = "goals";
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
