﻿using IVAXOR.PatreonNET.Constants;
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
using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;

namespace IVAXOR.PatreonNET.Services.API;

public class PatreonAPIQuery<TResponse, TAttributes, TRelationships>
    where TResponse : IPatreonResponse<TAttributes, TRelationships>
    where TAttributes : IPatreonAttributes
    where TRelationships : IPatreonRelationships
{
    public string Url { get; }

    protected HttpClient HttpClient { get; }
    protected IPatreonTokenManager TokenManager { get; }
    protected JsonSerializerOptions JsonSerializerOptions { get; } = PatreonJsonConstants.DefaultJsonSerializerOptions;

    protected internal HashSet<string> TopLevelIncludes { get; } = new(StringComparer.OrdinalIgnoreCase);
    protected internal Dictionary<string, HashSet<string>> IncludedFieldsByResource { get; } = new();
    protected internal int? PageSize { get; protected set; }
    protected internal Tuple<string, bool>? SortByDesc { get; protected set; }
    protected internal DateTime? Cursor { get; protected set; }

    public PatreonAPIQuery(
        string url,
        HttpClient httpClient,
        IPatreonTokenManager tokenManager)
    {
        Url = url;
        HttpClient = httpClient;
        TokenManager = tokenManager;
    }

    public PatreonAPIQuery(
        string url,
        HttpClient httpClient,
        IPatreonTokenManager tokenManager,
        JsonSerializerOptions jsonSerializerOptions)
    {
        Url = url;
        HttpClient = httpClient;
        TokenManager = tokenManager;
        JsonSerializerOptions = jsonSerializerOptions;
    }

    /// <exception cref="PatreonAPIException">Patreon API response do not contains success status code</exception>
    /// <exception cref="JsonException">Patreon API response contains new/unknown fields</exception>
    public async ValueTask<TResponse> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        var urlBuilder = new UriBuilder(Url);
        urlBuilder.Query = BuildQuery();
        var url = urlBuilder.ToString();

        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Authorization", $"Bearer {TokenManager.AccessToken}");

        using var response = await HttpClient.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode) throw new PatreonAPIException(response);

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TResponse>(json, JsonSerializerOptions);
    }

    public PatreonAPIQuery<TResponse, TAttributes, TRelationships> Include(string topLevelInclude)
    {
        TopLevelIncludes.Add(topLevelInclude);
        return this;
    }

    public PatreonAPIQuery<TResponse, TAttributes, TRelationships> IncludeField(string resourceName, string fieldName)
    {
        if (!IncludedFieldsByResource.TryGetValue(resourceName, out var fields)) fields = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        fields.Add(fieldName);
        IncludedFieldsByResource[resourceName] = fields;

        return this;
    }

    public PatreonAPIQuery<TResponse, TAttributes, TRelationships> IncludeField(Expression<Func<TAttributes, object>> selector)
    {
        return IncludeField<TAttributes>(selector);
    }

    public PatreonAPIQuery<TResponse, TAttributes, TRelationships> IncludeField<TNonBaseAttributes>(Expression<Func<TNonBaseAttributes, object>> selector)
        where TNonBaseAttributes : IPatreonAttributes
    {
        var memberInfo = selector.Body switch
        {
            MemberExpression me => me.Member,
            UnaryExpression ue => ((MemberExpression)ue.Operand).Member,
            _ => throw new NotImplementedException()
        };

        return IncludeField(memberInfo);
    }

    public PatreonAPIQuery<TResponse, TAttributes, TRelationships> IncludeField(MemberInfo memberInfo)
    {
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[memberInfo.DeclaringType];
        var fieldName = memberInfo.GetCustomAttribute<JsonPropertyNameAttribute>().Name;
        return IncludeField(resourceName, fieldName);
    }

    public PatreonAPIQuery<TResponse, TAttributes, TRelationships> IncludeAllFields()
    {
        return IncludeAllFields<TAttributes>();
    }

    public PatreonAPIQuery<TResponse, TAttributes, TRelationships> IncludeAllFields<TNonBaseAttributes>()
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

    /// <summary>
    /// Maximum number of results returned.
    /// </summary>
    public PatreonAPIQuery<TResponse, TAttributes, TRelationships> SetPageSize(int pageSize)
    {
        PageSize = pageSize;
        return this;
    }

    /// <summary>
    /// Comma-separated attributes to sort by, in order of precedence.
    /// Each attribute can be prepended with - to indicate descending order.
    /// Currently, we support created and updated for pledges.
    /// </summary>
    public PatreonAPIQuery<TResponse, TAttributes, TRelationships> SortBy(Expression<Func<TAttributes, DateTime?>> selector, bool descending)
    {
        var propertyInfo = selector.Body switch
        {
            MemberExpression me => me.Member,
            UnaryExpression ue => ((MemberExpression)ue.Operand).Member,
            _ => throw new NotImplementedException()
        };
        var fieldName = propertyInfo.GetCustomAttribute<JsonPropertyNameAttribute>().Name;
        return SortBy(fieldName, descending);
    }

    /// <summary>
    /// Comma-separated attributes to sort by, in order of precedence.
    /// Each attribute can be prepended with - to indicate descending order.
    /// Currently, we support created and updated for pledges.
    /// </summary>
    public PatreonAPIQuery<TResponse, TAttributes, TRelationships> SortBy(string fieldName, bool descending)
    {
        SortByDesc = new(fieldName, descending);
        return this;
    }

    /// <summary>
    /// From the sorted results, start returning where the first attribute in sort equals this value.
    /// </summary>
    public PatreonAPIQuery<TResponse, TAttributes, TRelationships> SetCursor(DateTime cursor)
    {
        Cursor = cursor;
        return this;
    }

    protected internal string BuildQuery()
    {
        var queryParams = HttpUtility.ParseQueryString(string.Empty);

        if (TopLevelIncludes.Any()) queryParams.Add("include", string.Join(",", TopLevelIncludes));

        var includedFields = IncludedFieldsByResource.ToDictionary(_ => $"fields[{_.Key}]", _ => string.Join(",", _.Value));
        if (includedFields.Any()) foreach (var includedField in includedFields) queryParams.Add(includedField.Key, includedField.Value);

        if (PageSize != null) queryParams.Add("page[count]", PageSize.Value.ToString());
        if (SortByDesc != null) queryParams.Add("sort", SortByDesc.Item2 ? $"-{SortByDesc.Item1}" : SortByDesc.Item1);
        if (SortByDesc != null && Cursor != null) queryParams.Add("page[cursor]", Cursor.Value.ToString("yyyy-MM-dd"));

        var query = queryParams.ToString();
        var decodedQuery = HttpUtility.UrlDecode(query);
        var patreonEncodedQuery = decodedQuery.Replace("[", "%5B").Replace("]", "%5D");

        return patreonEncodedQuery;
    }
}
