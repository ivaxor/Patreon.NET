using IVAXOR.PatreonNET.Models.Resources.CampaignsV1;
using IVAXOR.PatreonNET.Models.Resources.PledgeV1;
using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Collections.Generic;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets.V1;

public class PatreonUserV1Response
{
    public PatreonUserV1Attributes User { get; }

    public PatreonCampaignV1Attributes? Campaign { get; }

    public PatreonPledgeV1Attributes[] Pledges { get; }

    public PatreonUserV1Response(PatreonRawResponseSingle<PatreonUserV1Attributes, PatreonUserV1Relationships> response) : this(response.Data.Attributes, response.Data.Relationships, response.Included?.ToDictionary(_ => _.Id, _ => _)) { }

    public PatreonUserV1Response(PatreonUserV1Attributes attributes, PatreonUserV1Relationships? relationships, Dictionary<string, PatreonIncludeData>? includedData)
    {
        User = attributes;

        var campaignId = relationships?.Campaign?.Data?.Id;
        Campaign = campaignId == null ? null : (PatreonCampaignV1Attributes)includedData[campaignId].Attributes;

        var pledgesIds = relationships?.Pledges?.Data?.Select(_ => _.Id) ?? Enumerable.Empty<string>();
        Pledges = pledgesIds.Select(_ => includedData[_].Attributes).Cast<PatreonPledgeV1Attributes>().ToArray();
    }
}
