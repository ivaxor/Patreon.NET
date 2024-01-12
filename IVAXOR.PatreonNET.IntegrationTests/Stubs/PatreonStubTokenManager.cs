using IVAXOR.PatreonNET.Models;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;

namespace IVAXOR.PatreonNET.IntegrationTests.Stubs;

internal class PatreonStubTokenManager : IPatreonTokenManager
{
    public string AccessToken => PatreonClientTokens.AccessToken;

    protected PatreonClientTokens PatreonClientTokens { get; }

    public PatreonStubTokenManager()
    {
        using var appsettingsFileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("appsettings.json");
        var appsettings = JsonDocument.Parse(appsettingsFileStream);
        PatreonClientTokens = appsettings.RootElement.GetProperty(nameof(PatreonClientTokens)).Deserialize<PatreonClientTokens>();
    }
}
