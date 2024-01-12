# Setup
This page contains basic information on how to register OAuth client, install library package and managing/utilizing OAuth tokens.
If you are already familiar with such topics, you can skip this page and go to [V1](./V1.md) or [V2](./V2.md) API documentation.

## OAuth client registration
You will need to register OAuth client to get `client_id`, `client_secret` and other variables to access Patreon API.
Visit the [official OAuth documentation page](https://docs.patreon.com/#clients-and-api-keys) to get information on how to do that.

## Package installation
You will need to install NuGet package to use this library.
To do that you will need use command down below in project folder or install via IDE.
```powershell
dotnet add package IVAXOR.PatreonNET
```

## OAuth token management
Because Patreon API utilizes only OAuth `code` flow you will need to know few basic things in mind:
1. OAuth `code` flow is designed in mind with multi-user applications. So there will be complications, like web sign-in and tokens expiration, if you are developing server/admin-like application. This library does not come with any login flow, so you will need to get ready-to-use unexpired OAuth tokens elsewhere.
2. Be mindful about what `scopes` you are using. In most cases you do not need to specify all of them, especially if you are developing multi-user application. Some queries may behave differently with different set of scopes. You can read basic information about scopes on [official OAuth scopes page](https://docs.patreon.com/#scopes) and under specific endpoints.

## C# resource management
If you are new to C# resource management here are a few tips on how to run this library more efficiently:
1. Utilize `HttpClient` more efficiently by reading [official .NET guidelines for using HttpClient](https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient-guidelines).