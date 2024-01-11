namespace IVAXOR.PatreonNET.IntegrationTests.Stubs;

public static class AppSettingsProvider
{
    public static int CampaignId => JsonDocument.RootElement.GetProperty(nameof(CampaignId)).GetInt32();
    public static string MemberId => JsonDocument.RootElement.GetProperty(nameof(MemberId)).GetString();

    private static JsonDocument JsonDocument { get; }

    static AppSettingsProvider()
    {
        using var appsettingsFileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("appsettings.json");
        JsonDocument = JsonDocument.Parse(appsettingsFileStream);
    }
}
