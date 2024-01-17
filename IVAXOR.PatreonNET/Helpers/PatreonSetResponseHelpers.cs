using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Collections.Generic;
using System.Linq;
using IVAXOR.PatreonNET.Models.Resources.Benefits;
using IVAXOR.PatreonNET.Models.Resources.Deliverables;
using System;
using IVAXOR.PatreonNET.Models.Resources.Tiers;

namespace IVAXOR.PatreonNET.Helpers;

internal static class PatreonSetResponseHelpers
{
    internal static Tuple<PatreonBenefitAttributes, PatreonDeliverableAttributes[]>[] ParseBenefitsDeliverables(Dictionary<string, PatreonIncludeData> includeDataById, IEnumerable<PatreonIncludeData> includeData)
    {
        var benefitsDeliverables = new HashSet<Tuple<string, string>>();
        foreach (var data in includeData)
        {
            if (data.Relationships == null) continue;

            switch (data.Relationships)
            {
                case PatreonBenefitRelationships benefitRelationships:
                    benefitRelationships.Deliverables?.Data
                        ?.Select(_ => new Tuple<string, string>(data.Id, _.Id))
                        ?.ToList()
                        ?.ForEach(_ => benefitsDeliverables.Add(_));
                    break;
            }
        }

        return benefitsDeliverables
            .GroupBy(_ => _.Item1)
            .Select(_ =>
            {
                var benefit = (PatreonBenefitAttributes)includeDataById[_.Key].Attributes;
                var deliverables = _
                    .Select(__ => includeDataById[__.Item2].Attributes)
                    .Cast<PatreonDeliverableAttributes>()
                    .ToArray();

                return new Tuple<PatreonBenefitAttributes, PatreonDeliverableAttributes[]>(benefit, deliverables);
            })
            .ToArray();
    }

    internal static Tuple<PatreonTierAttributes, PatreonBenefitAttributes[]>[] ParseTiersBenefits(Dictionary<string, PatreonIncludeData> includeDataById, IEnumerable<PatreonIncludeData> includeData)
    {
        var tiersBenefits = new HashSet<Tuple<string, string>>();
        foreach (var data in includeData)
        {
            if (data.Relationships == null) continue;

            switch (data.Relationships)
            {
                case PatreonBenefitRelationships benefitRelationships:
                    benefitRelationships.Tiers?.Data
                        ?.Select(_ => new Tuple<string, string>(_.Id, data.Id))
                        ?.ToList()
                        ?.ForEach(_ => tiersBenefits.Add(_));
                    break;

                case PatreonTierRelationships tierRelationships:
                    tierRelationships.Benefits?.Data
                        ?.Select(_ => new Tuple<string, string>(data.Id, _.Id))
                        ?.ToList()
                        ?.ForEach(_ => tiersBenefits.Add(_));
                    break;
            }
        }

        return tiersBenefits
            .Distinct()
            .GroupBy(_ => _.Item1)
            .Select(_ =>
            {
                var tier = (PatreonTierAttributes)includeDataById[_.Key].Attributes;
                var benefits = _
                    .Select(__ => includeDataById[__.Item2].Attributes)
                    .Cast<PatreonBenefitAttributes>()
                    .ToArray();

                return new Tuple<PatreonTierAttributes, PatreonBenefitAttributes[]>(tier, benefits);
            })
            .ToArray();
    }

    internal static TAttributes[] ParseAllFromIncludeData<TAttributes>(IEnumerable<PatreonIncludeData> includeData)
        where TAttributes : IPatreonAttributes
    {
        return includeData
            .Select(_ => _.Attributes)
            .OfType<TAttributes>()
            .ToArray();
    }

    internal static TAttributes? ParseSingleFromIncludeData<TAttributes>(IEnumerable<PatreonIncludeData> includeData)
        where TAttributes : IPatreonAttributes
    {
        return includeData
            .Select(_ => _.Attributes)
            .OfType<TAttributes>()
            .SingleOrDefault();
    }

    internal static TAttributes? ParseFromIncludeData<TAttributes>(Dictionary<string, PatreonIncludeData> includeDataByTypeId, PatreonRelationshipsSingle? relationship)
        where TAttributes : IPatreonAttributes
    {
        if (relationship == null) return default;
        return (TAttributes)ParseFromIncludeData(includeDataByTypeId, relationship.Data).Attributes;
    }

    internal static TAttributes[]? ParseFromIncludeData<TAttributes>(Dictionary<string, PatreonIncludeData> includeDataByTypeId, PatreonRelationshipsMulti? relationships)
        where TAttributes : IPatreonAttributes
    {
        if (relationships == null) return new TAttributes[0];
        return relationships.Data.Select(_ => ParseFromIncludeData(includeDataByTypeId, _).Attributes).Cast<TAttributes>().ToArray();
    }

    private static PatreonIncludeData ParseFromIncludeData(Dictionary<string, PatreonIncludeData> includeDataByTypeId, PatreonRelationshipsData relationshipData)
    {
        return includeDataByTypeId[relationshipData.Id];
    }
}
