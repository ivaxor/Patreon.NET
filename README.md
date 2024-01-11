# Patreon.NET
[![GitHub build](https://img.shields.io/github/actions/workflow/status/ivaxor/Patreon.NET/dotnet.yml)](https://github.com/ivaxor/Patreon.NET)
[![Codacy grade](https://img.shields.io/codacy/grade/6f11ccec0a574668a3eacdfa47b87ea2)](https://app.codacy.com/gh/ivaxor/Patreon.NET/dashboard)
[![Coveralls coverage](https://img.shields.io/coverallsCoverage/github/ivaxor/Patreon.NET)](https://coveralls.io/github/ivaxor/Patreon.NET)
[![NuGet downloads](https://img.shields.io/nuget/dt/IVAXOR.PatreonNET?link=)](https://nuget.org/packages/IVAXOR.PatreonNET)
[![Patreon](https://img.shields.io/endpoint.svg?url=https%3A%2F%2Fshieldsio-patreon.vercel.app%2Fapi%3Fusername%3Dpatreon_NET%26type%3Dpatrons&style=flat)](https://patreon.com/patreon_NET)

.NET library for accessing [Patreon API](https://docs.patreon.com)

## Setup
You'll need to register an OAuth client account to receive a `client_id`, `client_secret` and other info for use with this module.
Visit the [OAuth Documentation Page](https://docs.patreon.com/#oauth) **while logged in as a Patreon creator on patreon.com** to register your client.

## Installation
Install with [dotnet CLI](https://learn.microsoft.com/en-us/dotnet/core/tools).
```powershell
dotnet add package IVAXOR.PatreonNET
```

## Usage
### Get OAuth tokens
Library doesn't support full OAuth flow because of `code` flow, so you will need to get provide OAuth tokens to the library.
If you aren't familiar with OAuth concept you should check it first.

### Manage OAuth tokens
Library have multiple ways to handle and manage OAuth tokens, but for simplicity of tutorial `PatreonSimpleTokenManager` will be chosen.
```csharp
var tokenManager = new PatreonSimpleTokenManager("access_token");
```

### API v1 calls (NOT RECOMMENDED)
```csharp
var httpClient = new HttpClient();
var patreonAPIv1 = new PatreonAPIv1(httpClient, tokenManager);

var currentUser = await patreonAPIv1.CurrentUser().ExecuteAsync();
var currentUserCampaigns = await patreonAPIv1.CurrentUserCampaigns().ExecuteAsync();
```

### API v2 calls
```csharp
var httpClient = new HttpClient();
var patreonAPIv2 = new PatreonAPIv2(httpClient, tokenManager);
var identity = await patreonAPIv2.Identity().IncludeAllFields().ExecuteAsync();
var campaigns = await PatreonAPIv2.Campaigns()
  .IncludeField(_ => _.OneLiner)
  .IncludeField(_ => _.PatronCount)
  .IncludeField(_ => _.Summary)
  .IncludeField(_ => _.Url)
  .ExecuteAsync();
```


### Other API calls
Solution includes `IVAXOR.PatreonNET.IntegrationTests` project with integration tests to run live request to API.
You can use them as examples or references to get familiar with library.
To run them you will need to create `IVAXOR.PatreonNET.IntegrationTests/appsettings.json` file and fill it with your OAuth tokens and other settings:
```json
{
  "CampaignId": 00000000,
  "MemberId": "00000000-0000-0000-0000-000000000000",
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
