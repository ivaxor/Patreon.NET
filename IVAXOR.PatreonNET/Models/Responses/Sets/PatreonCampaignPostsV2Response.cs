using IVAXOR.PatreonNET.Models.Resources.PostsV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets;

public class PatreonCampaignPostsV2Response
{
    public PatreonCampaignPostV2Response[] Posts { get; set; }

    public PatreonCampaignPostsV2Response(PatreonRawResponseMulti<PatreonPostV2Attributes, PatreonPostV2Relationships> response)
    {
        var includedData = response?.Included?.ToDictionary(_ => _.Id, _ => _);

        Posts = response.Data
            .Select(_ => new PatreonCampaignPostV2Response(_.Attributes, _.Relationships, includedData))
            .ToArray();
    }
}
