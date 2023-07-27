using IVAXOR.PatreonNET.Models.Relationships;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Deliverables
{
    public class PatreonDeliverableRelationships : IPatreonRelationships
    {
        /// <summary>
        /// The Benefit the Deliverables were generated for.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("benefit")]
        public PatreonRelationshipsSingle Benefit { get; set; }

        /// <summary>
        /// The Campaign the Deliverables were generated for.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("campaign")]
        public PatreonRelationshipsSingle Campaign { get; set; }

        /// <summary>
        /// The member who has been granted the deliverable.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("member")]
        public PatreonRelationshipsSingle Member { get; set; }

        /// <summary>
        /// The user who has been granted the deliverable.
        /// This user is the same as the member user.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("user")]
        public PatreonRelationshipsSingle User { get; set; }
    }
}
