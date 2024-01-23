using IVAXOR.PatreonNET.Models.Resources.CampaignsV1;
using IVAXOR.PatreonNET.Models.Resources.Goals;
using IVAXOR.PatreonNET.Models.Resources.PledgeV1;
using IVAXOR.PatreonNET.Models.Resources.Rewards;
using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Collections.Generic;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets.V1;

public class PatreonCampaignV1Response
{
    public PatreonCampaignV1Attributes Campaign { get; }

    public PatreonUserV1Attributes? Creator { get; }

    public PatreonGoalAttributes[] Goals { get; }

    public PatreonPledgeV1Attributes[] Pledges { get; }

    public PatreonRewardAttributes[] Rewards { get; }

    public PatreonCampaignV1Response(PatreonCampaignV1Attributes attributes, PatreonCampaignV1Relationships? relationships, Dictionary<string, PatreonIncludeData>? includedData)
    {
        Campaign = attributes;

        var creatorId = relationships?.Creator?.Data?.Id;
        Creator = creatorId == null ? null : (PatreonUserV1Attributes)includedData[creatorId].Attributes;

        var goalsIds = relationships?.Goals?.Data?.Select(_ => _.Id) ?? Enumerable.Empty<string>();
        Goals = goalsIds.Select(_ => includedData[_].Attributes).Cast<PatreonGoalAttributes>().ToArray();

        var pledgesIds = relationships?.Pledges?.Data?.Select(_ => _.Id) ?? Enumerable.Empty<string>();
        Pledges = pledgesIds.Select(_ => includedData[_].Attributes).Cast<PatreonPledgeV1Attributes>().ToArray();

        var rewardsIds = relationships?.Rewards?.Data?.Select(_ => _.Id) ?? Enumerable.Empty<string>();
        Rewards = rewardsIds.Select(_ => includedData[_].Attributes).Cast<PatreonRewardAttributes>().ToArray();
    }
}
