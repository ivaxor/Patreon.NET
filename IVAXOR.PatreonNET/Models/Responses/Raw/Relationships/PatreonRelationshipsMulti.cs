﻿using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Responses.Raw.Relationships;

public class PatreonRelationshipsMulti
{
    [JsonPropertyName("data")]
    public PatreonRelationshipsData[]? Data { get; set; }

    [JsonPropertyName("links")]
    public PatreonLinks? Links { get; set; }

    [JsonPropertyName("meta")]
    public PatreonMeta? Meta { get; set; }
}
