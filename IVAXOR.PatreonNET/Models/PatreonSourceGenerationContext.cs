using IVAXOR.PatreonNET.Models.Resources.Addresses;
using IVAXOR.PatreonNET.Models.Resources.Attachments;
using IVAXOR.PatreonNET.Models.Resources.Benefits;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV1;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Comments;
using IVAXOR.PatreonNET.Models.Resources.Deliverables;
using IVAXOR.PatreonNET.Models.Resources.Goals;
using IVAXOR.PatreonNET.Models.Resources.Likes;
using IVAXOR.PatreonNET.Models.Resources.Media;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.OAuths;
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
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models;

[JsonSerializable(typeof(PatreonLikeAttributes))]
[JsonSerializable(typeof(PatreonMediaAttributes))]
[JsonSerializable(typeof(PatreonPostTagAttributes))]
[JsonSerializable(typeof(PatreonRewardAttributes))]

[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonAddressAttributes, PatreonAddressRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonAttachmentAttributes, PatreonAttachmentRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonBenefitAttributes, PatreonBenefitRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonCampaignV1Attributes, PatreonCampaignV1Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonCommentAttributes, PatreonCommentRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonDeliverableAttributes, PatreonDeliverableRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonGoalAttributes, PatreonGoalRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonMemberAttributes, PatreonMemberRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonOAuthClientAttributes, PatreonOAuthClientRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonPledgeEventV2Attributes, PatreonPledgeEventV2Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonPledgeV1Attributes, PatreonPledgeV1Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonPostV1Attributes, PatreonPostV1Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonPostV2Attributes, PatreonPostV2Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonTierAttributes, PatreonTierRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonUserV1Attributes, PatreonUserV1Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseSingle<PatreonWebhookAttributes, PatreonWebhookRelationships>))]

[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonAddressAttributes, PatreonAddressRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonAttachmentAttributes, PatreonAttachmentRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonBenefitAttributes, PatreonBenefitRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonCampaignV1Attributes, PatreonCampaignV1Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonCommentAttributes, PatreonCommentRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonDeliverableAttributes, PatreonDeliverableRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonGoalAttributes, PatreonGoalRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonMemberAttributes, PatreonMemberRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonOAuthClientAttributes, PatreonOAuthClientRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonPledgeEventV2Attributes, PatreonPledgeEventV2Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonPledgeV1Attributes, PatreonPledgeV1Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonPostV1Attributes, PatreonPostV1Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonPostV2Attributes, PatreonPostV2Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonTierAttributes, PatreonTierRelationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonUserV1Attributes, PatreonUserV1Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonUserV2Attributes, PatreonUserV2Relationships>))]
[JsonSerializable(typeof(PatreonRawResponseMulti<PatreonWebhookAttributes, PatreonWebhookRelationships>))]

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Metadata)]
internal partial class PatreonSourceGenerationContext : JsonSerializerContext { }
