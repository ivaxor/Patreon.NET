using IVAXOR.PatreonNET.Models.Addresses;
using IVAXOR.PatreonNET.Models.Campaigns;
using IVAXOR.PatreonNET.Models.Members;
using IVAXOR.PatreonNET.Models.Pledges;
using IVAXOR.PatreonNET.Models.Tiers;
using IVAXOR.PatreonNET.Models.Users;
using IVAXOR.PatreonNET.Models.Webhooks;
using System;
using System.Collections.Generic;

namespace IVAXOR.PatreonNET.Constants
{
    public static class PatreonResponseDataTypes
    {
        public static readonly Dictionary<string, Type> PatreonAttributesByTypes = new Dictionary<string, Type>()
        {
            { "campaign", typeof(PatreonCampaignV2Attributes) },
            { "address", typeof(PatreonAddressAttributes) },
            { "tier", typeof(PatreonTierAttributes) },
            { "member", typeof(PatreonMemberAttributes) },
            { "user", typeof(PatreonUserV2Attributes) },
            { "webhook", typeof(PatreonWebhookAttributes) },
            { "pledge", typeof(PatreonPledgeEventAttributes) },
            { "reward", typeof(PatreonTierAttributes) }
        };

        public static readonly Dictionary<string, Type> PatreonRelationshipsByTypes = new Dictionary<string, Type>()
        {
            { "campaign", typeof(PatreonCampaignV2Relationships) },
            { "address", typeof(PatreonAddressRelationships) },
            { "tier", typeof(PatreonTierRelationships) },
            { "member", typeof(PatreonMemberRelationships) },
            { "user", typeof(PatreonUserV2Relationships) },
            { "webhook", typeof(PatreonWebhookRelationships) },
            { "pledge", typeof(PatreonPledgeEventRelationships) },
            { "reward", typeof(PatreonTierRelationships) }
        };
    }
}
