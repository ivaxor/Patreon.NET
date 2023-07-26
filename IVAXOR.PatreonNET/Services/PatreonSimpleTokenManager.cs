using IVAXOR.PatreonNET.Services.Interfaces;

namespace IVAXOR.PatreonNET.Services
{
    public class PatreonSimpleTokenManager : IPatreonTokenManager
    {
        public string AccessToken { get; set; }

        public PatreonSimpleTokenManager(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
