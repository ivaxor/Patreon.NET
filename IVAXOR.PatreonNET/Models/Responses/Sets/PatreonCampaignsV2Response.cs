using IVAXOR.PatreonNET.Helpers;
using IVAXOR.PatreonNET.Models.Resources.Benefits;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Goals;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Collections.Generic;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets;

public class PatreonCampaignsV2Response
{
    public PatreonCampaignV2Response[] Campaigns { get; }

    public PatreonCampaignsV2Response(PatreonRawResponseMulti<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> response)
    {
        var campaigns = new List<PatreonCampaignV2Response>();

        var campaign = response.Data.Single().Attributes;

        var includeDataById = response.Included?.ToDictionary(_ => _.Id, _ => _);
        if (includeDataById != null)
        {
            var benefits = PatreonSetResponseHelpers.ParseAllFromIncludeData<PatreonBenefitAttributes>(response.Included);
            var benefitsDeliverables = PatreonSetResponseHelpers.ParseBenefitsDeliverables(includeDataById, response.Included);

            var creator = PatreonSetResponseHelpers.ParseSingleFromIncludeData<PatreonUserV2Attributes>(response.Included);

            var tiers = PatreonSetResponseHelpers.ParseAllFromIncludeData<PatreonTierAttributes>(response.Included);
            var tiersBenefits = PatreonSetResponseHelpers.ParseTiersBenefits(includeDataById, response.Included);

            var goals = PatreonSetResponseHelpers.ParseAllFromIncludeData<PatreonGoalAttributes>(response.Included);

            campaigns.Add(new(campaign, benefits, benefitsDeliverables, creator, tiers, tiersBenefits, goals));
        }
        else campaigns.Add(new(campaign, null, null, null, null, null, null));

        Campaigns = campaigns.ToArray();
    }
}
