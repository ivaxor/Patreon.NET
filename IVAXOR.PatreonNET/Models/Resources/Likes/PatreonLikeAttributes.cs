using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Likes;

public class PatreonLikeAttributes : IPatreonAttributes
{
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }
}
