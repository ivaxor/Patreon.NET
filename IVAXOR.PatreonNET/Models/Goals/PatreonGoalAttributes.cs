using System.Text.Json.Serialization;
using System;
using IVAXOR.PatreonNET.Models.Interfaces;

namespace IVAXOR.PatreonNET.Models.Goals
{
    /// <summary>
    /// A funding goal in USD set by a creator on a campaign.
    /// </summary>
    public class PatreonGoalAttributes : IPatreonAttributes
    {
        /// <summary>
        /// Goal amount in USD cents.
        /// </summary>
        [JsonPropertyName("amount_cents")]
        public int AmountCents { get; set; }

        /// <summary>
        /// Equal to (pledge_sum/goal amount)*100, helpful when a creator
        /// </summary>
        [JsonPropertyName("completed_percentage")]
        public int CompletedPercentage { get; set; }

        /// <summary>
        /// When the goal was created for the campaign.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Goal description.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// When the campaign reached the goal.
        /// </summary>
        [JsonPropertyName("reached_at")]
        public DateTime? ReachedAt { get; set; }

        /// <summary>
        /// Goal title.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}