﻿using IVAXOR.PatreonNET.Models.Interfaces;
using IVAXOR.PatreonNET.Models.Relationships;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Addresses
{
    public class PatreonAddressRelationships : IPatreonRelationships
    {
        /// <summary>
        /// The campaigns that have access to the address.
        /// </summary>
        [JsonPropertyName("campaigns")]
        public PatreonRelationshipsMulti Campaigns { get; set; }

        /// <summary>
        /// The user this address belongs to.
        /// </summary>
        [JsonPropertyName("user")]
        public PatreonRelationshipsSingle User { get; set; }
    }
}
