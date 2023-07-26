using IVAXOR.PatreonNET.Services.Interfaces;
using System.Reflection;
using System.Text.Json;

namespace IVAXOR.PatreonNET.IntegrationTests.Stubs;

internal class PatreonStubTokenManager : IPatreonTokenManager
{
    public string AccessToken => PatreonClientTokens.AccessToken;
    public PatreonClientTokens PatreonClientTokens { get; protected set; }

    public PatreonStubTokenManager()
    {
        using var tokensFileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("IVAXOR.PatreonNET.IntegrationTests.tokens.json");
        PatreonClientTokens = JsonSerializer.Deserialize<PatreonClientTokens>(tokensFileStream);
    }
}
