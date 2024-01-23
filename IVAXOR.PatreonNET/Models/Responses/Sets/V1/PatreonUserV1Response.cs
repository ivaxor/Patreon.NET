using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Models.Responses.Raw;

namespace IVAXOR.PatreonNET.Models.Responses.Sets.V1;

public class PatreonUserV1Response
{
    public PatreonUserV1Attributes User { get; }

    public PatreonUserV1Response(PatreonRawResponseSingle<PatreonUserV1Attributes, PatreonUserV1Relationships> response)
    {
        
    }
}
