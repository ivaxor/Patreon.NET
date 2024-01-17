using IVAXOR.PatreonNET.Helpers;
using IVAXOR.PatreonNET.Models.Resources.Benefits;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Deliverables;
using IVAXOR.PatreonNET.Models.Resources.Goals;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System;
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
        var benefits = new PatreonBenefitAttributes[0];
        var benefitsDeliverables = new Tuple<PatreonBenefitAttributes, PatreonDeliverableAttributes[]>[0];
        PatreonUserV2Attributes? creator = null;
        var tiers = new PatreonTierAttributes[0];
        var tiersBenefits = new Tuple<PatreonTierAttributes, PatreonBenefitAttributes[]>[0];
        var goals = new PatreonGoalAttributes[0];

        var includeDataById = response.Included?.ToDictionary(_ => _.Id, _ => _);
        if (includeDataById != null)
        {
            benefits = PatreonSetResponseHelpers.ParseAllFromIncludeData<PatreonBenefitAttributes>(response.Included);
            benefitsDeliverables = PatreonSetResponseHelpers.ParseBenefitsDeliverables(includeDataById, response.Included);

            creator = PatreonSetResponseHelpers.ParseSingleFromIncludeData<PatreonUserV2Attributes>(response.Included);

            tiers = PatreonSetResponseHelpers.ParseAllFromIncludeData<PatreonTierAttributes>(response.Included);
            tiersBenefits = PatreonSetResponseHelpers.ParseTiersBenefits(includeDataById, response.Included);

            goals = PatreonSetResponseHelpers.ParseAllFromIncludeData<PatreonGoalAttributes>(response.Included);
        }

        campaigns.Add(new(campaign, benefits, benefitsDeliverables, creator, tiers, tiersBenefits, goals));

        Campaigns = campaigns.ToArray();
    }
}
