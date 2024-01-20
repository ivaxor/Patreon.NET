using IVAXOR.PatreonNET.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Constants;

internal static class PatreonJsonConstants
{
    public static JsonSerializerOptions DefaultJsonSerializerOptions => new()
    {
        UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
        TypeInfoResolver = PatreonSourceGenerationContext.Default
    };
}
