using IVAXOR.PatreonNET.Constants;
using IVAXOR.PatreonNET.Models.Response.Interfaces;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using IVAXOR.PatreonNET.Exceptions;
using System.Text.Json.Serialization;
using System.Web;

namespace IVAXOR.PatreonNET.Services.API;

public class PatreonAPIv2Query<TResponse, TAttributes, TRelationships>
    where TResponse : IPatreonResponse<TAttributes, TRelationships>
    where TAttributes : IPatreonAttributes
    where TRelationships : IPatreonRelationships
{
    public readonly string Url;

    protected readonly HttpClient HttpClient;
    protected readonly IPatreonTokenManager PatreonTokenManager;

    protected HashSet<string> TopLevelIncludes { get; } = new(StringComparer.OrdinalIgnoreCase);
    protected Dictionary<string, HashSet<string>> IncludedFieldsByResource { get; } = new();

    public PatreonAPIv2Query(
        string url,
        HttpClient httpClient,
        IPatreonTokenManager patreonTokenManager)
    {
        Url = url;
        HttpClient = httpClient;
        PatreonTokenManager = patreonTokenManager;
    }

    public PatreonAPIv2Query<TResponse, TAttributes, TRelationships> Include(string topLevelInclude)
    {
        TopLevelIncludes.Add(topLevelInclude);
        return this;
    }

    public PatreonAPIv2Query<TResponse, TAttributes, TRelationships> IncludeField(string resourceName, string fieldName)
    {
        if (!IncludedFieldsByResource.TryGetValue(resourceName, out var fields))
        {
            fields = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }
        fields.Add(fieldName);
        IncludedFieldsByResource[resourceName] = fields;

        return Include(resourceName);
    }

    public PatreonAPIv2Query<TResponse, TAttributes, TRelationships> IncludeField(Expression<Func<TAttributes, object>> selector)
    {
        return IncludeField<TAttributes>(selector);
    }

    public PatreonAPIv2Query<TResponse, TAttributes, TRelationships> IncludeField<TNonBaseAttributes>(Expression<Func<TNonBaseAttributes, object>> selector)
        where TNonBaseAttributes : IPatreonAttributes
    {
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(TNonBaseAttributes)];
        var propertyInfo = selector.Body switch
        {
            MemberExpression me => me.Member,
            UnaryExpression ue => ((MemberExpression)ue.Operand).Member,
            _ => throw new NotImplementedException()
        };

        var fieldName = propertyInfo.GetCustomAttribute<JsonPropertyNameAttribute>().Name;
        return IncludeField(resourceName, fieldName);
    }

    public PatreonAPIv2Query<TResponse, TAttributes, TRelationships> IncludeAllFields()
    {
        return IncludeAllFields<TAttributes>();
    }

    public PatreonAPIv2Query<TResponse, TAttributes, TRelationships> IncludeAllFields<TNonBaseAttributes>()
         where TNonBaseAttributes : IPatreonAttributes
    {
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(TNonBaseAttributes)];
        var fieldNames = typeof(TNonBaseAttributes).GetProperties()
            .Where(_ => _.GetCustomAttribute<JsonPropertyNameAttribute>() != null)
            .Select(_ => _.GetCustomAttribute<JsonPropertyNameAttribute>().Name)
            .ToList();
        fieldNames.ForEach(_ => IncludeField(resourceName, _));

        return this;
    }

    public async ValueTask<TResponse> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        var urlBuilder = new UriBuilder(Url);
        urlBuilder.Query = BuildQuery();
        var url = urlBuilder.ToString();

        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Authorization", $"Bearer {PatreonTokenManager.AccessToken}");

        using var response = await HttpClient.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode) throw new PatreonAPIException(response);

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TResponse>(json, Json.SerializerOptions);
    }

    protected string BuildQuery()
    {
        var topLevelIncldues = TopLevelIncludes
            .Where(_ => _ != PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(TAttributes)])
            .ToArray();
        var includedFields = IncludedFieldsByResource.ToDictionary(_ => $"fields[{_.Key}]", _ => string.Join(',', _.Value));

        var queryParams = HttpUtility.ParseQueryString(string.Empty);
        if (topLevelIncldues.Any()) queryParams.Add("include", string.Join(',', topLevelIncldues));
        if (includedFields.Any()) includedFields.AsParallel().ForAll(_ => queryParams.Add(_.Key, _.Value));

        var query = queryParams.ToString();
        var decodedQuery = HttpUtility.UrlDecode(query);
        var patreonEncodedQuery = decodedQuery.Replace("[", "%5B").Replace("]", "%5D");

        return patreonEncodedQuery;
    }
}
