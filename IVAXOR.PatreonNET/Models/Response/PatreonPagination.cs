﻿using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response;

public class PatreonPagination
{
    [JsonPropertyName("cursors")]
    public PatreonCursors? Cursors { get; set; }

    [JsonRequired]
    [JsonPropertyName("total")]
    public int Total { get; set; }
}
