using IVAXOR.PatreonNET.Models.Resources.Addresses;
using IVAXOR.PatreonNET.Models.Resources.PledgeV1;
using IVAXOR.PatreonNET.Models.Resources.Rewards;
using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Collections.Generic;

namespace IVAXOR.PatreonNET.Models.Responses.Sets.V1;

public class PatreonPledgeV1Response
{
    public PatreonPledgeV1Attributes Pledge { get; }

    public PatreonUserV1Attributes? Patron { get; set; }
    public PatreonRewardAttributes? Reward { get; set; }
    public PatreonUserV1Attributes? Creator { get; set; }
    public PatreonAddressAttributes? Address { get; set; }

    public PatreonPledgeV1Response(PatreonPledgeV1Attributes attributes, PatreonPledgeV1Relationships? relationships, Dictionary<string, PatreonIncludeData>? includedData)
    {
        Pledge = attributes;

        var patronId = relationships?.Patron?.Data?.Id;
        Patron = patronId == null ? null : (PatreonUserV1Attributes)includedData[patronId].Attributes;

        var rewardId = relationships?.Reward?.Data?.Id;
        Reward = rewardId == null ? null : (PatreonRewardAttributes)includedData[rewardId].Attributes;

        var creatorId = relationships?.Creator?.Data?.Id;
        Creator = creatorId == null ? null : (PatreonUserV1Attributes)includedData[creatorId].Attributes;

        var addressId = relationships?.Address?.Data?.Id;
        Address = addressId == null ? null : (PatreonAddressAttributes)includedData[addressId].Attributes;
    }
}
