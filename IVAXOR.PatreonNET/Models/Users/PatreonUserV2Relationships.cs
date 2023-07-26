﻿using IVAXOR.PatreonNET.Models.Interfaces;
using IVAXOR.PatreonNET.Models.Relationships;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Users
{
    public class PatreonUserV2Relationships : IPatreonRelationships
    {
        [JsonPropertyName("campaign")]
        public PatreonRelationshipsSingle Campaign { get; set; }

        [JsonPropertyName("memberships")]
        public PatreonRelationshipsMulti Memberships { get; set; }
    }
}