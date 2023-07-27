using IVAXOR.PatreonNET.Models;
using IVAXOR.PatreonNET.Models.Addresses;
using IVAXOR.PatreonNET.Models.Campaigns;
using IVAXOR.PatreonNET.Models.Members;
using IVAXOR.PatreonNET.Models.Pledges;
using IVAXOR.PatreonNET.Models.Tiers;
using IVAXOR.PatreonNET.Models.Users;
using IVAXOR.PatreonNET.Models.Webhooks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IVAXOR.PatreonNET.Constants
{
    internal static class PatreonResponseDataTypes
    {
        public static readonly Dictionary<string, Type> PatreonAttributesByTypes = new Dictionary<string, Type>()
        {
            { "campaign", typeof(PatreonCampaignAttributes) },
            { "address", typeof(PatreonAddressAttributes) },
            { "tier", typeof(PatreonTierAttributes) },
            { "member", typeof(PatreonMemberAttributes) },
            { "user", typeof(PatreonUserAttributes) },
            { "webhook", typeof(PatreonWebhookAttributes) },
            { "pledge", typeof(PatreonPledgeEventAttributes) },
            { "reward", typeof(PatreonRewardAttributes) }
        };
        public static readonly Dictionary<Type, string> TypeByPatreonAttributes = PatreonAttributesByTypes.ToDictionary(_ => _.Value, _ => _.Key);

        public static readonly Dictionary<string, Type> PatreonRelationshipsByTypes = new Dictionary<string, Type>()
        {
            { "campaign", typeof(PatreonCampaignRelationships) },
            { "address", typeof(PatreonAddressRelationships) },
            { "tier", typeof(PatreonTierRelationships) },
            { "member", typeof(PatreonMemberRelationships) },
            { "user", typeof(PatreonUserRelationships) },
            { "webhook", typeof(PatreonWebhookRelationships) },
            { "pledge", typeof(PatreonPledgeEventRelationships) }
        };
        public static readonly Dictionary<Type, string> TypeByPatreonRelationships = PatreonRelationshipsByTypes.ToDictionary(_ => _.Value, _ => _.Key);
    }
}
