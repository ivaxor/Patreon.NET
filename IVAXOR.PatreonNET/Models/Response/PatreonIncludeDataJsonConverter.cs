using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using IVAXOR.PatreonNET.Models.Response;
using IVAXOR.PatreonNET.Constants;
using IVAXOR.PatreonNET.Models.Response.Interfaces;

namespace IVAXOR.PatreonNET.JsonConverters;

public class PatreonIncludeDataJsonConverter : JsonConverter<PatreonIncludeData>
{
    public override PatreonIncludeData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);

        var patreonIncludeData = new PatreonIncludeData()
        {
            Id = jsonDocument.RootElement.GetProperty(nameof(PatreonIncludeData.Id).ToLower()).GetString(),
            Type = jsonDocument.RootElement.GetProperty(nameof(PatreonIncludeData.Type).ToLower()).GetString(),
        };

        if (jsonDocument.RootElement.TryGetProperty(nameof(PatreonIncludeData.Attributes).ToLower(), out var attributeJsonElement))
            if (PatreonResponseDataTypes.PatreonAttributesByTypes.TryGetValue(patreonIncludeData.Type, out var attributeType))
                patreonIncludeData.Attributes = (IPatreonAttributes)attributeJsonElement.Deserialize(attributeType, options);

        if (jsonDocument.RootElement.TryGetProperty(nameof(PatreonIncludeData.Relationships).ToLower(), out var relationshipsJsonElement))
            if (PatreonResponseDataTypes.PatreonRelationshipsByTypes.TryGetValue(patreonIncludeData.Type, out var relationshipsType))
                patreonIncludeData.Relationships = (IPatreonRelationships)relationshipsJsonElement.Deserialize(relationshipsType, options);

        return patreonIncludeData;
    }

    public override void Write(Utf8JsonWriter writer, PatreonIncludeData value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType());
    }
}
