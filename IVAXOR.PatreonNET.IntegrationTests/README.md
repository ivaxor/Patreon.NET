# Patreon.NET integration tests

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