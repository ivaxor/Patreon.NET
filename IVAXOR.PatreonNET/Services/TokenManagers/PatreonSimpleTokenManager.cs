using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;

namespace IVAXOR.PatreonNET.Services.TokenManagers;

public class PatreonSimpleTokenManager : IPatreonTokenManager
{
    public string AccessToken { get; }

    public PatreonSimpleTokenManager(string accessToken)
    {
        AccessToken = accessToken;
    }
}
