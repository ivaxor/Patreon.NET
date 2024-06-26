﻿using IVAXOR.PatreonNET.IntegrationTests.Stubs.Models;

namespace IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;

public static class AppSettingsProvider
{
    public static string CampaignId { get; }
    public static string MemberId { get; }
    public static string PostId { get; }

    public static string AccessToken { get; }

    static AppSettingsProvider()
    {
        using var appsettingsFileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("IVAXOR.PatreonNET.IntegrationTests.appsettings.json");
        var jsonDocument = JsonDocument.Parse(appsettingsFileStream);

        CampaignId = jsonDocument.RootElement.GetProperty(nameof(CampaignId)).GetString();
        MemberId = jsonDocument.RootElement.GetProperty(nameof(MemberId)).GetString();
        PostId = jsonDocument.RootElement.GetProperty(nameof(PostId)).GetString();

        var patreonClientTokens = jsonDocument.RootElement.GetProperty(nameof(PatreonClientTokens)).Deserialize<PatreonClientTokens>();
        AccessToken = patreonClientTokens.AccessToken;
    }
}
