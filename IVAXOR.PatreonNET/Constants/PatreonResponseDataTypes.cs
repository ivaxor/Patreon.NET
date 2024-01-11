using IVAXOR.PatreonNET.Models.Resources;
using IVAXOR.PatreonNET.Models.Resources.Addresses;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.Pledges;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Resources.Webhooks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IVAXOR.PatreonNET.Constants;

internal static class PatreonResponseDataTypes
{
    public static readonly Dictionary<string, Type> PatreonAttributesByTypes = new Dictionary<string, Type>()
        {
            { "campaign", typeof(PatreonCampaignV2Attributes) },
            { "address", typeof(PatreonAddressAttributes) },
            { "tier", typeof(PatreonTierAttributes) },
            { "memberships", typeof(PatreonMemberAttributes) },
            { "user", typeof(PatreonUserV2Attributes) },
            { "webhook", typeof(PatreonWebhookAttributes) },
            { "pledge", typeof(PatreonPledgeEventAttributes) },
            { "reward", typeof(PatreonRewardAttributes) }
        };
    public static readonly Dictionary<Type, string> TypeByPatreonAttributes = PatreonAttributesByTypes.ToDictionary(_ => _.Value, _ => _.Key);

    public static readonly Dictionary<string, Type> PatreonRelationshipsByTypes = new Dictionary<string, Type>()
        {
            { "campaign", typeof(PatreonCampaignV2Relationships) },
            { "address", typeof(PatreonAddressRelationships) },
            { "tier", typeof(PatreonTierRelationships) },
            { "memberships", typeof(PatreonMemberRelationships) },
            { "user", typeof(PatreonUserV2Relationships) },
            { "webhook", typeof(PatreonWebhookRelationships) },
            { "pledge", typeof(PatreonPledgeEventRelationships) }
        };
    public static readonly Dictionary<Type, string> TypeByPatreonRelationships = PatreonRelationshipsByTypes.ToDictionary(_ => _.Value, _ => _.Key);
}
