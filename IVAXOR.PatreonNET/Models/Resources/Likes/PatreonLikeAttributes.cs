using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Resources.Likes;

public class PatreonLikeAttributes : IPatreonAttributes
{
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }
}
