using IVAXOR.PatreonNET.Models.Relationships;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Pledges
{
    public class PatreonPledgeEventRelationships : IPatreonRelationships
    {
        /// <summary>
        /// The campaign being pledged to.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("campaign")]
        public PatreonRelationshipsSingle Campaign { get; set; }

        /// <summary>
        /// The pledging user.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("patron")]
        public PatreonRelationshipsSingle Patron { get; set; }

        /// <summary>
        /// The tier associated with this pledge event.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("tier")]
        public PatreonRelationshipsSingle Tier { get; set; }
    }
}