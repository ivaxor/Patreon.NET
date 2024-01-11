using IVAXOR.PatreonNET.Models.Relationships;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Addresses;

public class PatreonAddressRelationships : IPatreonRelationships
{
    /// <summary>
    /// The campaigns that have access to the address.
    /// </summary>
    [JsonPropertyName("campaigns")]
    public PatreonRelationshipsMulti? Campaigns { get; set; }

    /// <summary>
    /// The user this address belongs to.
    /// </summary>
    [JsonPropertyName("user")]
    public PatreonRelationshipsSingle? User { get; set; }
}
