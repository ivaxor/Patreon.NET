# Patreon.NET
[![GitHub build](https://img.shields.io/github/actions/workflow/status/ivaxor/Patreon.NET/dotnet.yml)](https://github.com/ivaxor/Patreon.NET)
[![Codacy grade](https://img.shields.io/codacy/grade/6f11ccec0a574668a3eacdfa47b87ea2)](https://app.codacy.com/gh/ivaxor/Patreon.NET/dashboard)
[![Coveralls coverage](https://img.shields.io/coverallsCoverage/github/ivaxor/Patreon.NET)](https://coveralls.io/github/ivaxor/Patreon.NET)
[![NuGet downloads](https://img.shields.io/nuget/dt/IVAXOR.PatreonNET?link=)](https://nuget.org/packages/IVAXOR.PatreonNET)
[![Patreon](https://img.shields.io/endpoint.svg?url=https%3A%2F%2Fshieldsio-patreon.vercel.app%2Fapi%3Fusername%3Dpatreon_NET%26type%3Dpatrons&style=flat)](https://patreon.com/patreon_NET)

.NET Standard 2.0 library for accessing [Patreon API](https://docs.patreon.com) on both V1 and V2.

## Library documentation
- [Setup guide](https://github.com/ivaxor/Patreon.NET/blob/master/Documentation/Setup.md)
- [Exceptions](hhttps://github.com/ivaxor/Patreon.NET/blob/master/Documentation/Exceptions.md)
- [V1 API code samples](https://github.com/ivaxor/Patreon.NET/blob/master/Documentation/V1.md)
- [V2 API code samples](https://github.com/ivaxor/Patreon.NET/blob/master/Documentation/V2.md)

## Tests
Solution includes `IVAXOR.PatreonNET.IntegrationTests` project with integration tests to run live request to API. You can use them as examples or references to get familiar with library.

To run them you will need to create `IVAXOR.PatreonNET.IntegrationTests/appsettings.json` file and fill it with your OAuth tokens and other settings:
```json
{
  "CampaignId": 00000000,
  "MemberId": "00000000-0000-0000-0000-000000000000",
  "PostId": 00000000,
  "PatreonClientTokens": {
    "access_token": "0000000000000000000000000000000000000000000",
    "expires_in": 2678400,
    "token_type": "Bearer",
    "scope": "identity identity[email] identity.memberships campaigns campaigns.members campaigns.posts w:campaigns.webhook",
    "refresh_token": "0000000000000000000000000000000000000000000",
    "version": "0.0.1"
  }
}
```