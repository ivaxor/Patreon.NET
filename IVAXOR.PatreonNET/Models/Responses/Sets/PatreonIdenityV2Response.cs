using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Collections.Generic;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets;
public class PatreonIdenityV2Response
{
    public PatreonUserV2Attributes Identity { get; }

    public PatreonCampaignV2Attributes Campaign { get; }

    public PatreonMemberAttributes[] Memberships { get; }

    public PatreonIdenityV2Response(PatreonRawResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships> response) : this(response.Data.Attributes, response.Data.Relationships, response.Included?.ToDictionary(_ => _.Id, _ => _)) { }

    public PatreonIdenityV2Response(PatreonUserV2Attributes attributes, PatreonUserV2Relationships relationships, Dictionary<string, PatreonIncludeData>? includedData)
    {
        Identity = attributes;

        var campaignId = relationships?.Campaign?.Data?.Id;
        Campaign = campaignId == null ? null : (PatreonCampaignV2Attributes)includedData[campaignId].Attributes;

        var membershipsIds = relationships?.Memberships?.Data?.Select(_ => _.Id) ?? Enumerable.Empty<string>();
        Memberships = membershipsIds.Select(_ => includedData[_].Attributes).Cast<PatreonMemberAttributes>().ToArray();
    }
}
