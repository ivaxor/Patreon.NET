using IVAXOR.PatreonNET.Models.Resources.Attachments;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV1;
using IVAXOR.PatreonNET.Models.Resources.Comments;
using IVAXOR.PatreonNET.Models.Resources.Likes;
using IVAXOR.PatreonNET.Models.Resources.PostsV1;
using IVAXOR.PatreonNET.Models.Resources.PostTags;
using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Collections.Generic;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets.V1;

public class PatreonPostV1Response
{
    public PatreonPostV1Attributes Post { get; }

    public PatreonAttachmentAttributes[] Attachments { get; }
    public PatreonCampaignV1Attributes? Campaign { get; }
    public object[] ContentLocks { get; }
    public PatreonLikeAttributes[] Likes { get; }
    public PatreonCommentAttributes[] Comments { get; }
    public PatreonUserV1Attributes? User { get; }
    public PatreonPostTagAttributes[] UserDefinedTags { get; }

    public PatreonPostV1Response(PatreonPostV1Attributes attributes, PatreonPostV1Relationships? relationships, Dictionary<string, PatreonIncludeData>? includedData)
    {
        Post = attributes;

        var attachmentsIds = relationships?.Attachments?.Data?.Select(_ => _.Id) ?? Enumerable.Empty<string>();
        Attachments = attachmentsIds.Select(_ => includedData[_].Attributes).Cast<PatreonAttachmentAttributes>().ToArray();

        var campaignId = relationships?.Campaign?.Data?.Id;
        Campaign = campaignId == null ? null : (PatreonCampaignV1Attributes)includedData[campaignId].Attributes;

        // TODO: Investigate ContentLocks schema
        ContentLocks = Enumerable.Empty<object>().ToArray();

        var likesIds = relationships?.Likes?.Data?.Select(_ => _.Id) ?? Enumerable.Empty<string>();
        Likes = likesIds.Select(_ => includedData[_].Attributes).Cast<PatreonLikeAttributes>().ToArray();

        var commentsIds = relationships?.Comments?.Data?.Select(_ => _.Id) ?? Enumerable.Empty<string>();
        Comments = commentsIds.Select(_ => includedData[_].Attributes).Cast<PatreonCommentAttributes>().ToArray();

        var userId = relationships?.User?.Data?.Id;
        User = userId == null ? null : (PatreonUserV1Attributes)includedData[userId].Attributes;

        var userDefinedTagsIds = relationships?.UserDefinedTags?.Data?.Select(_ => _.Id) ?? Enumerable.Empty<string>();
        UserDefinedTags = userDefinedTagsIds.Select(_ => includedData[_].Attributes).Cast<PatreonPostTagAttributes>().ToArray();
    }
}
