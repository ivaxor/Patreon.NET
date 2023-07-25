using System;

namespace IVAXOR.PatreonNET.Services
{
    public class PatreonAPI
    {
        private readonly string AccessToken;

        public PatreonAPI(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}