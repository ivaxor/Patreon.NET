using System.Threading.Tasks;
using System.Threading;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;
using System.Net.Http;
using System.Text.Json;
using IVAXOR.PatreonNET.Exceptions;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;

namespace IVAXOR.PatreonNET.Services.API;

public class PatreonAPIv1Query<TResponse, TAttributes, TRelationships>
    where TResponse : IPatreonResponse<TAttributes, TRelationships>
    where TAttributes : IPatreonAttributes
    where TRelationships : IPatreonRelationships
{
    public string Url { get; }

    protected HttpClient HttpClient { get; }
    protected IPatreonTokenManager TokenManager { get; }
    protected JsonSerializerOptions JsonSerializerOptions { get; }

    protected HashSet<string> TopLevelIncludes { get; } = new(StringComparer.OrdinalIgnoreCase);

    public PatreonAPIv1Query(
        string url,
        HttpClient httpClient,
        IPatreonTokenManager tokenManager)
    {
        Url = url;
        HttpClient = httpClient;
        TokenManager = tokenManager;
        JsonSerializerOptions = new()
        {
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
        };
    }

    public PatreonAPIv1Query(
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

    public PatreonAPIv1Query<TResponse, TAttributes, TRelationships> Include(string topLevelInclude)
    {
        TopLevelIncludes.Add(topLevelInclude);
        return this;
    }

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

    protected string BuildQuery()
    {
        var queryParams = HttpUtility.ParseQueryString(string.Empty);
        if (TopLevelIncludes.Any()) queryParams.Add("include", string.Join(",", TopLevelIncludes));

        var query = queryParams.ToString();
        var decodedQuery = HttpUtility.UrlDecode(query);
        var patreonEncodedQuery = decodedQuery.Replace("[", "%5B").Replace("]", "%5D");

        return patreonEncodedQuery;
    }
}
