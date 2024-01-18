using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets;

public class PatreonCampaignMembersV2Response
{
    public PatreonCampaignMemberV2Response[] Members { get; }

    public PatreonCampaignMembersV2Response(PatreonRawResponseMulti<PatreonMemberAttributes, PatreonMemberRelationships> response)
    {
        var includedData = response?.Included?.ToDictionary(_ => _.Id, _ => _);
        Members = response.Data
            .Select(_ => new PatreonCampaignMemberV2Response(_.Attributes, _.Relationships, includedData))
            .ToArray();
    }
}
