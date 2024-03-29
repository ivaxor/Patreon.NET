﻿using IVAXOR.PatreonNET.Models.Resources.Addresses;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.PledgeEventsV2;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Collections.Generic;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets.V2;

public class PatreonMembershipV2Response
{
    public PatreonMemberAttributes Member { get; }

    public PatreonAddressAttributes? Address { get; }
    public PatreonCampaignV2Attributes? Campaign { get; }
    public PatreonTierAttributes[] CurrentlyEntitledTiers { get; } = new PatreonTierAttributes[0];
    public PatreonPledgeEventV2Attributes[] PledgeHistory { get; } = new PatreonPledgeEventV2Attributes[0];
    public PatreonUserV2Attributes? User { get; }

    public PatreonMembershipV2Response(PatreonRawResponseSingle<PatreonMemberAttributes, PatreonMemberRelationships> response) : this(response.Data.Attributes, response.Data.Relationships, response.Included?.ToDictionary(_ => _.Id, _ => _)) { }

    public PatreonMembershipV2Response(PatreonMemberAttributes attributes, PatreonMemberRelationships relationships, Dictionary<string, PatreonIncludeData>? includedData)
    {
        Member = attributes;

        var addressId = relationships?.Address?.Data?.Id;
        Address = addressId == null ? null : (PatreonAddressAttributes)includedData[addressId].Attributes;

        var campaignId = relationships?.Campaign?.Data?.Id;
        Campaign = campaignId == null ? null : (PatreonCampaignV2Attributes)includedData[campaignId].Attributes;

        var currentlyEntitledTiersIds = relationships?.CurrentlyEntitledTiers?.Data?.Select(_ => _.Id) ?? Enumerable.Empty<string>();
        CurrentlyEntitledTiers = currentlyEntitledTiersIds.Select(_ => includedData[_].Attributes).Cast<PatreonTierAttributes>().ToArray();

        var pledgeHistoryIds = relationships?.PledgeHistory?.Data?.Select(_ => _.Id) ?? Enumerable.Empty<string>();
        PledgeHistory = pledgeHistoryIds.Select(_ => includedData[_].Attributes).Cast<PatreonPledgeEventV2Attributes>().ToArray();

        var userId = relationships?.User?.Data?.Id;
        User = userId == null ? null : (PatreonUserV2Attributes)includedData[userId].Attributes;
    }
}
