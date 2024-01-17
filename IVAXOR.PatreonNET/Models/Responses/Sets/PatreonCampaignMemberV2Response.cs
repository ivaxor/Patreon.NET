using IVAXOR.PatreonNET.Models.Resources.Addresses;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;

namespace IVAXOR.PatreonNET.Models.Responses.Sets;

public class PatreonCampaignMemberV2Response
{
    public PatreonMemberAttributes Member { get; }

    public PatreonAddressAttributes? Address { get; }
    public PatreonCampaignV2Attributes? Campaign { get; }
    public PatreonTierAttributes[] Tiers { get; } = new PatreonTierAttributes[0];
    public PatreonUserV2Attributes? User { get; }

    public PatreonCampaignMemberV2Response(PatreonMemberAttributes member, PatreonAddressAttributes? address, PatreonCampaignV2Attributes? campaign, PatreonTierAttributes[] tiers, PatreonUserV2Attributes? user)
    {
        Member = member;
        Address = address;
        Campaign = campaign;
        Tiers = tiers;
        User = user;
    }
}
