using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Attachments;

public class PatreonAttachmentAttributes : IPatreonAttributes
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
