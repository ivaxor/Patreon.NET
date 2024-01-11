﻿using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response;

public class PatreonResponseMulti<TAttributes, TRelationships> : PatreonResponseBase, IPatreonResponse<TAttributes, TRelationships>
    where TAttributes : IPatreonAttributes
    where TRelationships : IPatreonRelationships
{
    [JsonRequired]
    [JsonPropertyName("data")]
    public PatreonData<TAttributes, TRelationships>[] Data { get; set; }
}
