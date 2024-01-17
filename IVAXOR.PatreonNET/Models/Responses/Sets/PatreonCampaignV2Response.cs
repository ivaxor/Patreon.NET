using IVAXOR.PatreonNET.Helpers;
using IVAXOR.PatreonNET.Models.Resources.Benefits;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Goals;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System;
using System.Linq;
using IVAXOR.PatreonNET.Models.Resources.Deliverables;

namespace IVAXOR.PatreonNET.Models.Responses.Sets;

public class PatreonCampaignV2Response
{
    public PatreonCampaignV2Attributes Campaign { get; }

    public PatreonBenefitAttributes[] Benefits { get; } = new PatreonBenefitAttributes[0];
    public Tuple<PatreonBenefitAttributes, PatreonDeliverableAttributes[]>[] BenefitsDeliverables { get; } = new Tuple<PatreonBenefitAttributes, PatreonDeliverableAttributes[]>[0];

    public PatreonUserV2Attributes? Creator { get; }

    public PatreonTierAttributes[] Tiers { get; } = new PatreonTierAttributes[0];
    public Tuple<PatreonTierAttributes, PatreonBenefitAttributes[]>[] TiersBenefits { get; } = new Tuple<PatreonTierAttributes, PatreonBenefitAttributes[]>[0];

    public PatreonGoalAttributes[] Goals { get; } = new PatreonGoalAttributes[0];

    public PatreonCampaignV2Response(PatreonRawResponseSingle<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> response)
    {
        Campaign = response.Data.Attributes;

        if (response.Included != null)
        {
            var includeDataById = response.Included.ToDictionary(_ => _.Id, _ => _);

            Benefits = PatreonSetResponseHelpers.ParseAllFromIncludeData<PatreonBenefitAttributes>(response.Included);
            BenefitsDeliverables = PatreonSetResponseHelpers.ParseBenefitsDeliverables(includeDataById, response.Included);

            Creator = PatreonSetResponseHelpers.ParseSingleFromIncludeData<PatreonUserV2Attributes>(response.Included);

            Tiers = PatreonSetResponseHelpers.ParseAllFromIncludeData<PatreonTierAttributes>(response.Included);
            TiersBenefits = PatreonSetResponseHelpers.ParseTiersBenefits(includeDataById, response.Included);

            Goals = PatreonSetResponseHelpers.ParseAllFromIncludeData<PatreonGoalAttributes>(response.Included);
        }
    }

    public PatreonCampaignV2Response(
        PatreonCampaignV2Attributes campaign,
        PatreonBenefitAttributes[] benefits,
        Tuple<PatreonBenefitAttributes, PatreonDeliverableAttributes[]>[] benefitsDeliverables,
        PatreonUserV2Attributes? creator,
        PatreonTierAttributes[] tiers,
        Tuple<PatreonTierAttributes, PatreonBenefitAttributes[]>[] tiersBenefits,
        PatreonGoalAttributes[] goals)
    {
        Campaign = campaign;
        Benefits = benefits;
        BenefitsDeliverables = benefitsDeliverables;
        Creator = creator;
        Tiers = tiers;
        TiersBenefits = tiersBenefits;
        Goals = goals;
    }
}
