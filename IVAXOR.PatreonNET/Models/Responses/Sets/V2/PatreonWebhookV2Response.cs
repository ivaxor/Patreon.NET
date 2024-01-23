using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.OAuths;
using IVAXOR.PatreonNET.Models.Resources.Webhooks;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using System.Collections.Generic;

namespace IVAXOR.PatreonNET.Models.Responses.Sets.V2;

public class PatreonWebhookV2Response
{
    public PatreonWebhookAttributes Webhook { get; }

    public PatreonCampaignV2Attributes? Campaign { get; }
    public PatreonOAuthClientAttributes? Client { get; }

    public PatreonWebhookV2Response(PatreonWebhookAttributes attributes, PatreonWebhookRelationships relationships, Dictionary<string, PatreonIncludeData>? includedData)
    {
        Webhook = attributes;

        var campaignId = relationships?.Campaign?.Data?.Id;
        Campaign = campaignId == null ? null : (PatreonCampaignV2Attributes)includedData[campaignId].Attributes;

        var clientId = relationships?.Campaign?.Data?.Id;
        Client = clientId == null ? null : (PatreonOAuthClientAttributes)includedData[clientId].Attributes;
    }
}
