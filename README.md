# Patreon.NET
![Nuget](https://img.shields.io/nuget/dt/IVAXOR.PatreonNET?label=NuGet)

.NET library for accessing [Patreon API](https://docs.patreon.com)

## Setup
You'll need to register an OAuth client account to receive a `client_id`, `client_secret` and other info for use with this module.
Visit the [OAuth Documentation Page](https://docs.patreon.com/#oauth) **while logged in as a Patreon creator on patreon.com** to register your client.

## Installation
Install with [dotnet CLI]([https://www.npmjs.com](https://learn.microsoft.com/en-us/dotnet/core/tools/)) or manually via your IDE UI.
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

### API v1 calls
```csharp
var httpClient = new HttpClient();
var patreonAPIv1 = new PatreonAPIv1(httpClient, tokenManager);

var currentUser = await PatreonAPIv1.CurrentUser().ExecuteAsync();
var currentUserCampaings = await PatreonAPIv1.CurrentUserCampaigns().ExecuteAsync();
```

### API v2 calls (in development)
