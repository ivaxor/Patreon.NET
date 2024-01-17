﻿using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Attachments;

public class PatreonAttachmentRelationships : IPatreonRelationships
{
    [JsonPropertyName("post")]
    public PatreonRelationshipsSingle? Post { get; set; }
}
