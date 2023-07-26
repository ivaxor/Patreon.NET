using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using IVAXOR.PatreonNET.Models.Response;
using IVAXOR.PatreonNET.Constants;
using IVAXOR.PatreonNET.Models.Interfaces;

namespace IVAXOR.PatreonNET.JsonConverters
{
    public class PatreonIncludeDataJsonConverter : JsonConverter<PatreonIncludeData>
    {
        public override PatreonIncludeData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);

            var type = jsonDocument.RootElement.GetProperty(nameof(PatreonIncludeData.Type).ToLower()).GetString();
            var attributeType = PatreonResponseDataTypes.PatreonAttributesByTypes[type];
            var relationshipsType = PatreonResponseDataTypes.PatreonRelationshipsByTypes[type];

            return new PatreonIncludeData()
            {
                Id = jsonDocument.RootElement.GetProperty(nameof(PatreonIncludeData.Id).ToLower()).GetString(),
                Type = type,
                Attributes = (IPatreonAttributes)jsonDocument.RootElement.Deserialize(attributeType, options),
                Relationships = (IPatreonRelationships)jsonDocument.RootElement.Deserialize(relationshipsType, options)
            };
        }

        public override void Write(Utf8JsonWriter writer, PatreonIncludeData value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType());
        }
    }
}
