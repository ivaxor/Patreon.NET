using IVAXOR.PatreonNET.Helpers;
using IVAXOR.PatreonNET.Models.Resources.Addresses;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Collections.Generic;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets;

public class PatreonCampaignMembersV2Response
{
    public PatreonCampaignMemberV2Response[] Members { get; }

    public PatreonCampaignMembersV2Response(PatreonRawResponseMulti<PatreonMemberAttributes, PatreonMemberRelationships> response)
    {
        var members = new List<PatreonCampaignMemberV2Response>();

        var includeDataById = response?.Included?.ToDictionary(_ => _.Id, _ => _);
        foreach (var data in response.Data)
        {
            var member = data.Attributes;
            PatreonAddressAttributes? address = null;
            PatreonCampaignV2Attributes? campaign = null;
            PatreonTierAttributes[]? tiers = null;
            PatreonUserV2Attributes? user = null;

            if (includeDataById != null)
            {
                address = PatreonSetResponseHelpers.ParseFromIncludeData<PatreonAddressAttributes>(includeDataById, data.Relationships.Address);
                campaign = PatreonSetResponseHelpers.ParseFromIncludeData<PatreonCampaignV2Attributes>(includeDataById, data.Relationships.Campaign);
                tiers = PatreonSetResponseHelpers.ParseFromIncludeData<PatreonTierAttributes>(includeDataById, data.Relationships.CurrentlyEntitledTiers);
                user = PatreonSetResponseHelpers.ParseFromIncludeData<PatreonUserV2Attributes>(includeDataById, data.Relationships.User);
            }

            members.Add(new(member, address, campaign, tiers, user));
        }

        Members = members.ToArray();
    }
}
