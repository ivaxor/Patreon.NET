using IVAXOR.PatreonNET.Models.Resources;
using IVAXOR.PatreonNET.Models.Resources.Addresses;
using IVAXOR.PatreonNET.Models.Resources.Benefits;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV1;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Goals;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.PledgeEventsV2;
using IVAXOR.PatreonNET.Models.Resources.PledgeV1;
using IVAXOR.PatreonNET.Models.Resources.PostsV2;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Resources.Webhooks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IVAXOR.PatreonNET.Constants;

internal static class PatreonResponseDataTypes
{
    public static readonly IReadOnlyDictionary<string, IEnumerable<Type>> PatreonAttributesByTypes = new Dictionary<string, IEnumerable<Type>>()
    {
        { "user", new[] { typeof(PatreonUserV1Attributes), typeof(PatreonUserV2Attributes) } },
        { "campaign", new[] { typeof(PatreonCampaignV1Attributes), typeof(PatreonCampaignV2Attributes) } },
        { "pledge", new[] { typeof(PatreonPledgeV1Attributes), typeof(PatreonPledgeEventV2Attributes) } },
        { "post", new[] { typeof(PatreonPostV2Attributes) } },
        { "address", new[] { typeof(PatreonAddressAttributes) } },
        { "tier", new[] { typeof(PatreonTierAttributes) } },
        { "member", new[] { typeof(PatreonMemberAttributes) } },
        { "webhook", new[] { typeof(PatreonWebhookAttributes) } },
        { "reward", new[] { typeof(PatreonRewardAttributes) } },
        { "benefit", new[] { typeof(PatreonBenefitAttributes) } },
        { "goal", new[] { typeof(PatreonGoalAttributes) } }
    };

    public static readonly IReadOnlyDictionary<string, IEnumerable<Type>> PatreonRelationshipsByTypes = new Dictionary<string, IEnumerable<Type>>()
    {
        { "user", new[] { typeof(PatreonUserV1Relationships), typeof(PatreonUserV2Relationships) } },
        { "campaign", new[] { typeof(PatreonCampaignV1Relationships), typeof(PatreonCampaignV2Relationships) } },
        { "pledge", new[] { typeof(PatreonPledgeV1Relationships), typeof(PatreonPledgeEventV2Relationships) } },
        { "address", new[] { typeof(PatreonAddressRelationships) } },
        { "tier", new[] { typeof(PatreonTierRelationships) } },
        { "member", new[] { typeof(PatreonMemberRelationships) } },
        { "webhook", new[] { typeof(PatreonWebhookRelationships) } }
    };

    public static readonly IReadOnlyDictionary<Type, string> TypeByPatreonAttributes = PatreonAttributesByTypes
        .SelectMany(_ => _.Value, (kvp, t) => new KeyValuePair<Type, string>(t, kvp.Key))
        .ToDictionary(_ => _.Key, _ => _.Value);

    public static readonly IReadOnlyDictionary<Type, string> TypeByPatreonRelationships = PatreonRelationshipsByTypes
        .SelectMany(_ => _.Value, (kvp, t) => new KeyValuePair<Type, string>(t, kvp.Key))
        .ToDictionary(_ => _.Key, _ => _.Value);
}
