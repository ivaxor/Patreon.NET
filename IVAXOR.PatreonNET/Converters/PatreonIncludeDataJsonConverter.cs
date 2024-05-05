using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using IVAXOR.PatreonNET.Constants;
using System.Collections.Generic;
using System.Linq;
using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;

namespace IVAXOR.PatreonNET.Converters;

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
            if (PatreonResponseDataTypes.PatreonAttributesByTypes.TryGetValue(patreonIncludeData.Type, out var attributeTypes))
                patreonIncludeData.Attributes = (IPatreonAttributes)IterativeParse(attributeJsonElement, attributeTypes, options);

        if (jsonDocument.RootElement.TryGetProperty(nameof(PatreonIncludeData.Relationships).ToLower(), out var relationshipsJsonElement))
            if (PatreonResponseDataTypes.PatreonRelationshipsByTypes.TryGetValue(patreonIncludeData.Type, out var relationshipsType))
                patreonIncludeData.Relationships = (IPatreonRelationships)IterativeParse(relationshipsJsonElement, relationshipsType, options);

        return patreonIncludeData;
    }

    public override void Write(Utf8JsonWriter writer, PatreonIncludeData value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType());
    }

    protected object IterativeParse(JsonElement attributeJsonElement, IEnumerable<Type> attributeTypes, JsonSerializerOptions options)
    {
        if (attributeTypes.Count() == 1) return attributeJsonElement.Deserialize(attributeTypes.Single(), options);

        var exceptions = new List<JsonException>();
        foreach (var attributeType in attributeTypes)
        {
            try
            {
                return attributeJsonElement.Deserialize(attributeType, options);
            }
            catch (JsonException exception)
            {
                exceptions.Add(exception);
            }
        }

        throw new AggregateException(exceptions);
    }
}
