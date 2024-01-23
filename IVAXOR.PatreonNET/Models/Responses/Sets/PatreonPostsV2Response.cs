using IVAXOR.PatreonNET.Models.Resources.PostsV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets;

public class PatreonPostsV2Response
{
    public PatreonPostV2Response[] Posts { get; set; }

    public PatreonPostsV2Response(PatreonRawResponseMulti<PatreonPostV2Attributes, PatreonPostV2Relationships> response)
    {
        var includedData = response?.Included?.ToDictionary(_ => _.Id, _ => _);

        Posts = response.Data
            .Select(_ => new PatreonPostV2Response(_.Attributes, _.Relationships, includedData))
            .ToArray();
    }
}
