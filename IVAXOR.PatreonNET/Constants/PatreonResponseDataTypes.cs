using IVAXOR.PatreonNET.Models.Resources.Addresses;
using IVAXOR.PatreonNET.Models.Resources.Attachments;
using IVAXOR.PatreonNET.Models.Resources.Benefits;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV1;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Goals;
using IVAXOR.PatreonNET.Models.Resources.Likes;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.PledgeEventsV2;
using IVAXOR.PatreonNET.Models.Resources.PledgeV1;
using IVAXOR.PatreonNET.Models.Resources.PostsV1;
using IVAXOR.PatreonNET.Models.Resources.PostsV2;
using IVAXOR.PatreonNET.Models.Resources.PostTags;
using IVAXOR.PatreonNET.Models.Resources.Rewards;
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
        { "address", new[] { typeof(PatreonAddressAttributes) } },
        { "attachment", new[] { typeof(PatreonAttachmentAttributes) } },
        { "benefit", new[] { typeof(PatreonBenefitAttributes) } },
        { "campaign", new[] { typeof(PatreonCampaignV1Attributes), typeof(PatreonCampaignV2Attributes) } },
        { "goal", new[] { typeof(PatreonGoalAttributes) } },
        { "like", new[] { typeof(PatreonLikeAttributes) } },
        { "member", new[] { typeof(PatreonMemberAttributes) } },
        { "pledge", new[] { typeof(PatreonPledgeV1Attributes), typeof(PatreonPledgeEventV2Attributes) } },
        { "post", new[] { typeof(PatreonPostV1Attributes), typeof(PatreonPostV2Attributes) } },
        { "post_tag", new[] { typeof(PatreonPostTagAttributes) } },
        { "reward", new[] { typeof(PatreonRewardAttributes) } },
        { "tier", new[] { typeof(PatreonTierAttributes) } },
        { "user", new[] { typeof(PatreonUserV1Attributes), typeof(PatreonUserV2Attributes) } },
        { "webhook", new[] { typeof(PatreonWebhookAttributes) } }
    };

    public static readonly IReadOnlyDictionary<string, IEnumerable<Type>> PatreonRelationshipsByTypes = new Dictionary<string, IEnumerable<Type>>()
    {
        { "address", new[] { typeof(PatreonAddressRelationships) } },
        { "attachment", new[] { typeof(PatreonAttachmentRelationships) } },
        { "benefit", new[] { typeof(PatreonBenefitRelationships) } },
        { "campaign", new[] { typeof(PatreonCampaignV1Relationships), typeof(PatreonCampaignV2Relationships) } },
        { "goal", new[] { typeof(PatreonGoalRelationships) } },
        { "member", new[] { typeof(PatreonMemberRelationships) } },
        { "pledge", new[] { typeof(PatreonPledgeV1Relationships), typeof(PatreonPledgeEventV2Relationships) } },
        { "post", new[] { typeof(PatreonPostV1Relationships), typeof(PatreonPostV2Relationships) } },
        { "tier", new[] { typeof(PatreonTierRelationships) } },
        { "user", new[] { typeof(PatreonUserV1Relationships), typeof(PatreonUserV2Relationships) } },
        { "webhook", new[] { typeof(PatreonWebhookRelationships) } }
    };

    public static readonly IReadOnlyDictionary<Type, string> TypeByPatreonAttributes = PatreonAttributesByTypes
        .SelectMany(_ => _.Value, (kvp, t) => new KeyValuePair<Type, string>(t, kvp.Key))
        .ToDictionary(_ => _.Key, _ => _.Value);

    public static readonly IReadOnlyDictionary<Type, string> TypeByPatreonRelationships = PatreonRelationshipsByTypes
        .SelectMany(_ => _.Value, (kvp, t) => new KeyValuePair<Type, string>(t, kvp.Key))
        .ToDictionary(_ => _.Key, _ => _.Value);
}
