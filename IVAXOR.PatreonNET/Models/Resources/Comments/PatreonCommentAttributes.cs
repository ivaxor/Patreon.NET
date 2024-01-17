using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Comments;

public class PatreonCommentAttributes : IPatreonAttributes
{
    [JsonPropertyName("body")]
    public string? Body { get; set; }

    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [JsonPropertyName("is_by_creator")]
    public bool? IsByCreator { get; set; }

    [JsonPropertyName("is_by_patron")]
    public bool? IsByPatron { get; set; }

    [JsonPropertyName("is_liked_by_creator")]
    public bool? IsLikedByCreator { get; set; }

    [JsonPropertyName("moderation_status")]
    public string? ModerationStatus { get; set; }

    [JsonPropertyName("visibility_state")]
    public string? VisibilityState { get; set; }

    [JsonPropertyName("vote_sum")]
    public int? VoteSum { get; set; }
}
