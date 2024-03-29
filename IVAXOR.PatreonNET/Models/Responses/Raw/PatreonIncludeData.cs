﻿using IVAXOR.PatreonNET.Converters;
using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Responses.Raw;

[JsonConverter(typeof(PatreonIncludeDataJsonConverter))]
public class PatreonIncludeData
{
    [JsonRequired]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonRequired]
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("attributes")]
    public IPatreonAttributes? Attributes { get; set; }

    [JsonPropertyName("relationships")]
    public IPatreonRelationships? Relationships { get; set; }
}
