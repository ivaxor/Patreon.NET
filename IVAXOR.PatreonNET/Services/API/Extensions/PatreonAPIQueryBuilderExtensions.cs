using IVAXOR.PatreonNET.Constants;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Services.API.Extensions
{
    public static class PatreonAPIQueryBuilderExtensions
    {
        public static string? GetIncludeAdditionalFieldsQuery<TResponse, TAttributes, TRelationships>(this PatreonAPIv1Query<TResponse, TAttributes, TRelationships> query)
            where TResponse : IPatreonResponse<TAttributes, TRelationships>
            where TAttributes : IPatreonAttributes
            where TRelationships : IPatreonRelationships
        {
            if (!query.IncludeAdditionalFields.Any()) return null;

            var rootObjectName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(TAttributes)];
            var propertyInfoByNames = typeof(TAttributes).GetProperties().ToDictionary(_ => _.Name, _ => _);
            var includedFieldNames = query.IncludeAdditionalFields
                .Select(_ => propertyInfoByNames[_])
                .Select(_ => (JsonPropertyNameAttribute)_.GetCustomAttribute(typeof(JsonPropertyNameAttribute)))
                .Select(_ => _.Name)
                .ToHashSet();

            return $"fields[{rootObjectName}]={string.Join(',', includedFieldNames)}";
        }

        public static string? GetTopLevelIncludeQuery<TResponse, TAttributes, TRelationships>(this PatreonAPIv2Query<TResponse, TAttributes, TRelationships> query)
            where TResponse : IPatreonResponse<TAttributes, TRelationships>
            where TAttributes : IPatreonAttributes
            where TRelationships : IPatreonRelationships
        {
            if (!query.TopLevelIncludes.Any()) return null;

            return $"include={string.Join(',', query.TopLevelIncludes)}";
        }

        public static string? GetIncludeFieldsQuery<TResponse, TAttributes, TRelationships>(this PatreonAPIv2Query<TResponse, TAttributes, TRelationships> query)
            where TResponse : IPatreonResponse<TAttributes, TRelationships>
            where TAttributes : IPatreonAttributes
            where TRelationships : IPatreonRelationships
        {
            if (!query.IncludeFields.Any()) return null;

            var rootObjectName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(TAttributes)];
            var propertyInfoByNames = typeof(TAttributes).GetProperties().ToDictionary(_ => _.Name, _ => _);
            var includedFieldNames = query.IncludeFields
                .Select(_ => propertyInfoByNames[_])
                .Select(_ => (JsonPropertyNameAttribute)_.GetCustomAttribute(typeof(JsonPropertyNameAttribute)))
                .Select(_ => _.Name)
                .ToHashSet();

            return $"fields[{rootObjectName}]={string.Join(',', includedFieldNames)}";
        }
    }
}
