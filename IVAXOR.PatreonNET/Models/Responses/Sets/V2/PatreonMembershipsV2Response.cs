using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets.V2;

public class PatreonMembershipsV2Response
{
    public PatreonMembershipV2Response[] Members { get; }

    public PatreonMembershipsV2Response(PatreonRawResponseMulti<PatreonMemberAttributes, PatreonMemberRelationships> response)
    {
        var includedData = response?.Included?.ToDictionary(_ => _.Id, _ => _);
        Members = response.Data
            .Select(_ => new PatreonMembershipV2Response(_.Attributes, _.Relationships, includedData))
            .ToArray();
    }
}
