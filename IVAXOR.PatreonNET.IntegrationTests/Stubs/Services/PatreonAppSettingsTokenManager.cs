using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;

namespace IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;

internal class PatreonAppSettingsTokenManager : IPatreonTokenManager
{
    public string AccessToken => AppSettingsProvider.AccessToken;
}
