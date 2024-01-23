using IVAXOR.PatreonNET.Models.Resources.Webhooks;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Linq;

namespace IVAXOR.PatreonNET.Models.Responses.Sets.V2;

public class PatreonWebhooksV2Response
{
    public PatreonWebhookV2Response[] Webhooks { get; }

    public PatreonWebhooksV2Response(PatreonRawResponseMulti<PatreonWebhookAttributes, PatreonWebhookRelationships> response)
    {
        var includedData = response?.Included?.ToDictionary(_ => _.Id, _ => _);

        Webhooks = response.Data
            .Select(_ => new PatreonWebhookV2Response(_.Attributes, _.Relationships, includedData))
            .ToArray();
    }
}
