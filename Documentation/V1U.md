# Patreon V1 undocumented API
This page contains information and code samples on how to access Patreon V1 undocumented API using this library.

## Notes
Most of this information was gathered via reverse engineering of Patreon API though web portals and manual testing.
Also some information was brought from [oxguy3's reverse engineering documentation](https://github.com/oxguy3/patreon-api).

## Prerequisites
```csharp
var httpClient = new HttpClient();
var tokenManager = new PatreonSimpleTokenManager("access_token");
var patreonAPIv1 = new PatreonAPIv1(httpClient, tokenManager);
```

# API endpoint code samples

## Campaign posts including comments, likes and other
```csharp
var campaignId = 0;
var response = await PatreonAPIv1.CampaignPosts(campaignId)
  .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Attachments)
  .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Campaign)
  .Include(PatreonTopLevelIncludes.V1.CampaignPosts.ContentLocks)
  .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Comments)
  .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Likes)
  .Include(PatreonTopLevelIncludes.V1.CampaignPosts.User)
  .Include(PatreonTopLevelIncludes.V1.CampaignPosts.UserDefinedTags)
  .ExecuteAsync();
var posts = new PatreonPostsV1Response(response);
```
