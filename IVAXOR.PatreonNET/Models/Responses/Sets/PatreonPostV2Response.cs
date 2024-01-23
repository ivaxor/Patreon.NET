using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.PostsV2;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Collections.Generic;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets;

public class PatreonPostV2Response
{
    public PatreonPostV2Attributes Post { get; set; }
    public PatreonUserV2Attributes? User { get; set; }
    public PatreonCampaignV2Attributes? Campaign { get; set; }

    public PatreonPostV2Response(PatreonRawResponseSingle<PatreonPostV2Attributes, PatreonPostV2Relationships> response) : this(response.Data.Attributes, response.Data.Relationships, response.Included?.ToDictionary(_ => _.Id, _ => _)) { }

    public PatreonPostV2Response(PatreonPostV2Attributes attributes, PatreonPostV2Relationships relationships, Dictionary<string, PatreonIncludeData>? includedData)
    {
        Post = attributes;

        var userId = relationships?.User?.Data?.Id;
        User = userId == null ? null : (PatreonUserV2Attributes)includedData[userId].Attributes;

        var campaignId = relationships?.Campaign?.Data?.Id;
        Campaign = campaignId == null ? null : (PatreonCampaignV2Attributes)includedData[campaignId].Attributes;
    }
}
