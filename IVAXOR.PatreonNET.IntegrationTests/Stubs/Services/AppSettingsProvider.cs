using IVAXOR.PatreonNET.IntegrationTests.Stubs.Models;

namespace IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;

public static class AppSettingsProvider
{
    public static int CampaignId { get; }
    public static string MemberId { get; }
    public static int PostId { get; }

    public static string AccessToken { get; }

    static AppSettingsProvider()
    {
        using var appsettingsFileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("appsettings.json");
        var jsonDocument = JsonDocument.Parse(appsettingsFileStream);

        CampaignId = jsonDocument.RootElement.GetProperty(nameof(CampaignId)).GetInt32();
        MemberId = jsonDocument.RootElement.GetProperty(nameof(MemberId)).GetString();
        PostId = jsonDocument.RootElement.GetProperty(nameof(PostId)).GetInt32();

        var patreonClientTokens = jsonDocument.RootElement.GetProperty(nameof(PatreonClientTokens)).Deserialize<PatreonClientTokens>();
        AccessToken = patreonClientTokens.AccessToken;
    }
}
