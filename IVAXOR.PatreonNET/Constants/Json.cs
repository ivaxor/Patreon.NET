using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace IVAXOR.PatreonNET.Constants;

internal static class Json
{
    internal static readonly JsonSerializerOptions SerializerOptions;

    static Json()
    {
        SerializerOptions = new JsonSerializerOptions()
        {
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers = { AddMissingMemberHandling }
            }
        };
    }

    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/migrate-from-newtonsoft?pivots=dotnet-7-0#handle-missing-members
    /// </summary>
    /// <param name="typeInfo"></param>
    /// <exception cref="JsonException"></exception>
    internal static void AddMissingMemberHandling(JsonTypeInfo typeInfo)
    {
        if (typeInfo.Kind == JsonTypeInfoKind.Object &&
            typeInfo.Properties.All(prop => !prop.IsExtensionData) &&
            typeInfo.OnDeserialized is null)
        {
            // Dynamically attach dictionaries to deserialized objects.
            var cwt = new ConditionalWeakTable<object, Dictionary<string, object>>();

            var propertyInfo = typeInfo.CreateJsonPropertyInfo(typeof(Dictionary<string, object>), "__extensionDataAttribute");
            propertyInfo.Get = obj => cwt.TryGetValue(obj, out Dictionary<string, object>? value) ? value : null;
            propertyInfo.Set = (obj, value) => cwt.Add(obj, (Dictionary<string, object>)value!);
            propertyInfo.IsExtensionData = true;
            typeInfo.Properties.Add(propertyInfo);
            typeInfo.OnDeserialized = obj =>
            {
                if (cwt.TryGetValue(obj, out Dictionary<string, object>? dict))
                {
                    cwt.Remove(obj);
                    throw new JsonException($"JSON properties {string.Join(", ", dict.Keys)} could not bind to any members of type {typeInfo.Type}");
                }
            };
        }
    }
}
