using IVAXOR.PatreonNET.Models.Interfaces;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonPostV2Relationships : IPatreonRelationships
    {
        /// <summary>
        /// The author of the post.
        /// </summary>
        [JsonPropertyName("user")]
        public PatreonUserV2Attributes user { get; set; }

        /// <summary>
        /// The campaign that the membership is for.
        /// </summary>
        [JsonPropertyName("campaign")]
        public PatreonCampaignV2Attributes campaign { get; set; }
    }
}