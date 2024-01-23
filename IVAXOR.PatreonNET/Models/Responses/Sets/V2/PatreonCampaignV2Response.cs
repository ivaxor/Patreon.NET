using IVAXOR.PatreonNET.Models.Resources.Benefits;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Goals;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Linq;
using IVAXOR.PatreonNET.Models.Resources.Deliverables;
using System.Collections.Generic;

namespace IVAXOR.PatreonNET.Models.Responses.Sets.V2;

public class PatreonCampaignV2Response
{
    public PatreonCampaignV2Attributes Campaign { get; }

    public PatreonBenefitAttributes[] Benefits { get; } = new PatreonBenefitAttributes[0];
    public Dictionary<PatreonBenefitAttributes, PatreonDeliverableAttributes[]> BenefitsDeliverables { get; } = new();

    public PatreonUserV2Attributes? Creator { get; }

    public PatreonTierAttributes[] Tiers { get; } = new PatreonTierAttributes[0];
    public Dictionary<PatreonTierAttributes, PatreonBenefitAttributes[]> TiersBenefits { get; } = new();

    public PatreonGoalAttributes[] Goals { get; } = new PatreonGoalAttributes[0];

    public PatreonCampaignV2Response(PatreonRawResponseSingle<PatreonCampaignV2Attributes, PatreonCampaignV2Relationships> response) : this(response.Data.Attributes, response.Data.Relationships, response.Included?.ToDictionary(_ => _.Id, _ => _)) { }

    public PatreonCampaignV2Response(PatreonCampaignV2Attributes attributes, PatreonCampaignV2Relationships? relationships, Dictionary<string, PatreonIncludeData>? includedData)
    {
        Campaign = attributes;

        var benefitsIds = relationships?.Benefits?.Data?.Select(_ => _.Id) ?? Enumerable.Empty<string>();
        var benefitsData = benefitsIds.Select(_ => includedData[_]).ToArray();
        Benefits = benefitsData.Select(_ => _.Attributes).Cast<PatreonBenefitAttributes>().ToArray();

        foreach (var benefit in Benefits)
        {
            var benefitDeliverablesIds = benefitsData
                .Select(_ => _.Relationships)
                .Cast<PatreonBenefitRelationships>()
                .Where(_ => _ != null)
                .SelectMany(_ => _?.Deliverables?.Data?.Select(__ => __.Id))
                .ToArray();
            var benefitDeliverables = benefitDeliverablesIds.Select(_ => includedData[_].Attributes).Cast<PatreonDeliverableAttributes>().ToArray();

            BenefitsDeliverables.Add(benefit, benefitDeliverables);
        }

        var creatorId = relationships?.Creator?.Data?.Id;
        Creator = creatorId == null ? null : (PatreonUserV2Attributes)includedData[creatorId].Attributes;

        var tierIds = relationships?.Tiers?.Data?.Select(_ => _.Id) ?? Enumerable.Empty<string>();
        var tiersData = tierIds.Select(_ => includedData[_]).ToArray();
        Tiers = tiersData.Select(_ => _.Attributes).Cast<PatreonTierAttributes>().ToArray();

        foreach (var tier in Tiers)
        {
            var tierBenefitsIds = tiersData
                .Select(_ => _.Relationships)
                .Cast<PatreonTierRelationships>()
                .Where(_ => _ != null)
                .SelectMany(_ => _?.Benefits?.Data?.Select(__ => __.Id))
                .ToArray();
            var tierBenefits = tierBenefitsIds.Select(_ => includedData[_].Attributes).Cast<PatreonBenefitAttributes>().ToArray();

            TiersBenefits.Add(tier, tierBenefits);
        }

        var goalIds = relationships?.Goals?.Data?.Select(_ => _.Id) ?? Enumerable.Empty<string>();
        Goals = goalIds.Select(_ => includedData[_].Attributes).Cast<PatreonGoalAttributes>().ToArray();
    }
}
