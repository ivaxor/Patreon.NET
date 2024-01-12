# Exceptions

## [PatreonAPIException](../IVAXOR.PatreonNET/Exceptions/PatreonAPIException.cs)
This is custom exception introduced in this library. 
Can be thrown if HTTP response from Patreon API does not contains successful status code.
Exception contains `StatusCode` and `Response` properties.

## [JsonException](https://learn.microsoft.com/dotnet/api/system.text.json.jsonexception)
This is `System.Text.Json` exception.
Can be thrown when JSON data can't be parsed exactly to C# objects because of `UnmappedMemberHandling` set to `JsonUnmappedMemberHandling.Disallow` in library.
This could indicates that something is wrong because of library bugs or Patreon V2 API changes.

You can bypass `UnmappedMemberHandling` library default setting either by creating `PatreonAPIv1` / `PatreonAPIv2` or `PatreonAPIv1Query` / `PatreonAPIv2Query` object using constructor with `jsonSerializerOptions` variable, like this:
```csharp
var httpClient = new HttpClient();
var tokenManager = new PatreonSimpleTokenManager("access_token");
var jsonSerializerOptions = new JsonSerializerOptions();
var patreonAPIv2 = new PatreonAPIv2(httpClient, tokenManager, jsonSerializerOptions);
```

Please, create an issue on GitHub if you encounter this exception during your workflow.