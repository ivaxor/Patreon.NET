using IVAXOR.PatreonNET.Models.Resources.CampaignsV1;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets.V1;

public class PatreonCampaignsV1Response
{
    public PatreonCampaignV1Response[] Campaigns { get; }

    public PatreonCampaignsV1Response(PatreonRawResponseMulti<PatreonCampaignV1Attributes, PatreonCampaignV1Relationships> response)
    {
        var includedData = response.Included?.ToDictionary(_ => _.Id, _ => _);

        Campaigns = response.Data
            .Select(_ => new PatreonCampaignV1Response(_.Attributes, _.Relationships, includedData))
            .ToArray();
    }
}
