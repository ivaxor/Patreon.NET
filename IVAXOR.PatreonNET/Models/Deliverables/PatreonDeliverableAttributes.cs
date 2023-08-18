using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Deliverables
{
    public class PatreonDeliverableAttributes : IPatreonAttributes
    {
        /// <summary>
        /// When the creator marked the deliverable as completed or fulfilled to the patron.
        /// </summary>
        [JsonPropertyName("completed_at")]
        public DateTime? CompletedAt { get; set; }

        /// <summary>
        /// One of delivered, not_delivered, wont_deliver.
        /// </summary>
        [JsonPropertyName("delivery_status")]
        public string? DeliveryStatus { get; set; }

        /// <summary>
        /// When the deliverable is due to the patron.
        /// </summary>
        [JsonPropertyName("due_at")]
        public DateTime? DueAt { get; set; }
    }
}
