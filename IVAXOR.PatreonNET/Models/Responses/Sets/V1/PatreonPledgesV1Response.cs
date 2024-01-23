using IVAXOR.PatreonNET.Models.Resources.PledgeV1;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets.V1;

public class PatreonPledgesV1Response
{
    public PatreonPledgeV1Response[] Pledges { get; }

    public PatreonPledgesV1Response(PatreonRawResponseMulti<PatreonPledgeV1Attributes, PatreonPledgeV1Relationships> response)
    {
        var includedData = response.Included?.ToDictionary(_ => _.Id, _ => _);

        Pledges = response.Data
            .Select(_ => new PatreonPledgeV1Response(_.Attributes, _.Relationships, includedData))
            .ToArray();
    }
}
