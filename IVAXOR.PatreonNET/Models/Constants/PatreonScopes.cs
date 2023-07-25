namespace IVAXOR.PatreonNET.Models.Constants
{
    public static class PatreonScopes
    {
        /// <summary>
        /// Provides read access to data about the user.
        /// </summary>
        public const string Identity = "identity";

        /// <summary>
        /// Provides read access to the user’s email.
        /// </summary>
        public const string IdentityEmail = "identity[email]";

        /// <summary>
        /// Provides read access to the user’s memberships.
        /// </summary>
        public const string IdentityMemberships = "identity.memberships";

        /// <summary>
        /// Provides read access to basic campaign data.
        /// </summary>
        public const string Campaigns = "campaigns";

        /// <summary>
        /// Provides read, write, update, and delete access to the campaign’s webhooks created by the client.
        /// </summary>
        public const string CampaignsWebhook = "w:campaigns.webhook";

        /// <summary>
        /// Provides read access to data about a campaign’s members. Also allows the same information to be sent via webhooks created by your client.
        /// </summary>
        public const string CampaignsMembers = "campaigns.members";

        /// <summary>
        /// Provides read access to the member’s email. Also allows the same information to be sent via webhooks created by your client.
        /// </summary>
        public const string CampaignsMembersEmail = "campaigns.members[email]";

        /// <summary>
        /// Provides read access to the member’s address, if an address was collected in the pledge flow. Also allows the same information to be sent via webhooks created by your client.
        /// </summary>
        public const string CampaignsMembersAddress = "campaigns.members.address";

        /// <summary>
        /// Provides read access to the posts on a campaign.
        /// </summary>
        public const string CampaignsPosts = "campaigns.posts";
    }
}
