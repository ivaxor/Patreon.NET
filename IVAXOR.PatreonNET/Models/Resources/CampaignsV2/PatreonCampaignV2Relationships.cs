﻿using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.CampaignsV2;

public class PatreonCampaignV2Relationships : IPatreonRelationships
{
    /// <summary>
    /// The campaign's benefits.
    /// </summary>
    [JsonPropertyName("benefits")]
    public PatreonRelationshipsMulti? Benefits { get; set; }

    [JsonPropertyName("campaign_installations")]
    public PatreonRelationshipsMulti? CampaignInstallations { get; set; }

    /// <summary>
    /// The campaign's categories.
    /// </summary>
    [JsonPropertyName("categories")]
    public PatreonRelationshipsMulti? Categories { get; set; }

    /// <summary>
    /// The campaign owner.
    /// </summary>
    [JsonPropertyName("creator")]
    public PatreonRelationshipsSingle? Creator { get; set; }

    /// <summary>
    /// The campaign's goals.
    /// </summary>
    [JsonPropertyName("goals")]
    public PatreonRelationshipsMulti? Goals { get; set; }

    /// <summary>
    /// The campaign's tiers.
    /// </summary>
    [JsonPropertyName("tiers")]
    public PatreonRelationshipsMulti? Tiers { get; set; }
}
