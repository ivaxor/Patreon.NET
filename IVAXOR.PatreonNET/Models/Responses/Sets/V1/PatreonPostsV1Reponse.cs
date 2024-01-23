using IVAXOR.PatreonNET.Models.Resources.PostsV1;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets.V1;

public class PatreonPostsV1Reponse
{
    public PatreonPostV1Reponse[] Posts { get; }

    public PatreonPostsV1Reponse(PatreonRawResponseMulti<PatreonPostV1Attributes, PatreonPostV1Relationships> response)
    {
        var includedData = response.Included?.ToDictionary(_ => _.Id, _ => _);

        Posts = response.Data
            .Select(_ => new PatreonPostV1Reponse(_.Attributes, _.Relationships, includedData))
            .ToArray();
    }
}
