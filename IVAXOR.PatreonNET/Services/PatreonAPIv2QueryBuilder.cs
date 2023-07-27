using IVAXOR.PatreonNET.Constants;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Services
{
    public static class PatreonAPIv2QueryBuilder
    {
        public static string GetIncludeFieldsQuery<TAttribute>(PatreonAPIv2Query<TAttribute> query)
            where TAttribute : IPatreonAttributes
        {
            var rootObjectName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(TAttribute)];

            var propertyInfoByNames = typeof(TAttribute).GetProperties().ToDictionary(_ => _.Name, _ => _);

            var includedFieldNames = query.IncludeFields
                .Select(_ => propertyInfoByNames[_])
                .Select(_ => (JsonPropertyNameAttribute)_.GetCustomAttribute(typeof(JsonPropertyNameAttribute)))
                .Select(_ => _.Name)
                .ToHashSet();

            return $"fields[{rootObjectName}]={string.Join(',', includedFieldNames)}";
        }
    }
}
