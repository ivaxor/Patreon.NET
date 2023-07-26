using IVAXOR.PatreonNET.Models.Interfaces;
using IVAXOR.PatreonNET.Models.Relationships;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Goals
{
    public class PatreonGoalRelationships : IPatreonRelationships
    {
        /// <summary>
        /// The campaign trying to reach the goal.
        /// </summary>
        [JsonPropertyName("campaign")]
        public PatreonRelationshipsSingle Campaign { get; set; }
    }
}