using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets;

public class PatreonCampaignsV2Response
{
    public PatreonCampaignV2Response[] Campaigns { get; }

    public PatreonCampaignsV2Response(PatreonRawResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> response)
    {
        var includedData = response.Included?.ToDictionary(_ => _.Id, _ => _);

        Campaigns = response.Data
            .Select(_ => new PatreonCampaignV2Response(_.Attributes, _.Relationships, includedData))
            .ToArray();
    }
}
