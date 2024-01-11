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
    public readonly string Url;

    protected readonly HttpClient HttpClient;
    protected readonly IPatreonTokenManager PatreonTokenManager;

    public PatreonAPIv1Query(
        string url,
        HttpClient httpClient,
        IPatreonTokenManager patreonTokenManager)
    {
        Url = url;
        HttpClient = httpClient;
        PatreonTokenManager = patreonTokenManager;
    }

    public async ValueTask<TResponse> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, Url);
        request.Headers.Add("Authorization", $"Bearer {PatreonTokenManager.AccessToken}");

        using var response = await HttpClient.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode) throw new PatreonAPIException(response);

        using var responseStream = await response.Content.ReadAsStreamAsync();

        return await JsonSerializer.DeserializeAsync<TResponse>(responseStream, Json.SerializerOptions, cancellationToken);
    }
}
