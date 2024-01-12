using IVAXOR.PatreonNET.Models.Response.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;
using System.Net.Http;
using IVAXOR.PatreonNET.Constants;
using System.Text.Json;
using IVAXOR.PatreonNET.Exceptions;

namespace IVAXOR.PatreonNET.Services.API;

public class PatreonAPIv1Query<TResponse, TAttributes, TRelationships>
    where TResponse : IPatreonResponse<TAttributes, TRelationships>
    where TAttributes : IPatreonAttributes
    where TRelationships : IPatreonRelationships
{
    public string Url { get; }

    protected HttpClient HttpClient { get; }
    protected IPatreonTokenManager TokenManager { get; }

    public PatreonAPIv1Query(
        string url,
        HttpClient httpClient,
        IPatreonTokenManager tokenManager)
    {
        Url = url;
        HttpClient = httpClient;
        TokenManager = tokenManager;
    }

    public async ValueTask<TResponse> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, Url);
        request.Headers.Add("Authorization", $"Bearer {TokenManager.AccessToken}");

        using var response = await HttpClient.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode) throw new PatreonAPIException(response);

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TResponse>(json, Json.SerializerOptions);
    }
}
