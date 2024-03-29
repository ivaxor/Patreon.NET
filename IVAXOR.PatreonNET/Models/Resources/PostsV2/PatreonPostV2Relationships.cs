﻿using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.PostsV2;

public class PatreonPostV2Relationships : IPatreonRelationships
{
    /// <summary>
    /// The author of the post.
    /// </summary>
    [JsonPropertyName("user")]
    public PatreonRelationshipsSingle? User { get; set; }

    /// <summary>
    /// The campaign that the membership is for.
    /// </summary>
    [JsonPropertyName("campaign")]
    public PatreonRelationshipsSingle? Campaign { get; set; }
}