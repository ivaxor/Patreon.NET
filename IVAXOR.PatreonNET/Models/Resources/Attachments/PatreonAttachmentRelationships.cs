using IVAXOR.PatreonNET.Models.Response.Relationships;
using IVAXOR.PatreonNET.Models.Response.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Attachments;

public class PatreonAttachmentRelationships : IPatreonRelationships
{
    [JsonPropertyName("post")]
    public PatreonRelationshipsSingle? Post { get; set; }
}

