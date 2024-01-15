using IVAXOR.PatreonNET.Models.Response.Relationships;
using IVAXOR.PatreonNET.Models.Response.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Webhooks;

public class PatreonWebhookRelationships : IPatreonRelationships
{
    /// <summary>
    /// The campaign whose events trigger the webhook.
    /// </summary>
    [JsonPropertyName("campaign")]
    public PatreonRelationshipsSingle? Campaign { get; set; }

    /// <summary>
    /// The client which created the webhook.
    /// </summary>
    [JsonPropertyName("client")]
    public PatreonRelationshipsSingle? Client { get; set; }
}
