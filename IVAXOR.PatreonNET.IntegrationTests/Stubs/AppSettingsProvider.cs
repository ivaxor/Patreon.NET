namespace IVAXOR.PatreonNET.IntegrationTests.Stubs;

public static class AppSettingsProvider
{
    public static int CampaignId { get; }
    public static string MemberId { get; }
    public static int PostId { get; }

    private static JsonDocument JsonDocument { get; }

    static AppSettingsProvider()
    {
        using var appsettingsFileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("appsettings.json");
        JsonDocument = JsonDocument.Parse(appsettingsFileStream);
        CampaignId = JsonDocument.RootElement.GetProperty(nameof(CampaignId)).GetInt32();
        MemberId = JsonDocument.RootElement.GetProperty(nameof(MemberId)).GetString();
        PostId = JsonDocument.RootElement.GetProperty(nameof(PostId)).GetInt32();
    }
}
