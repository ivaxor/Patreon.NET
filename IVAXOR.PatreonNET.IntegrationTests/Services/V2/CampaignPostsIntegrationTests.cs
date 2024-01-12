namespace IVAXOR.PatreonNET.IntegrationTests.Services.V2;

[TestClass]
public class CampaignPostsIntegrationTests
{
    protected PatreonAPIv2 PatreonAPIv2 { get; }

    public CampaignPostsIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonStubTokenManager();

        PatreonAPIv2 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task CampaignPosts()
    {
        // Act
        var campaignPosts = await PatreonAPIv2.CampaignPosts(AppSettingsProvider.CampaignId).ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPosts.Data.All(_ => _.Type == "post"));
    }

    [TestMethod]
    public async Task CampaignPosts_Full_IncludeField()
    {
        // Act
        var campaignPosts = await PatreonAPIv2.CampaignPosts(AppSettingsProvider.CampaignId)
            .IncludeField(_ => _.AppId)
            .IncludeField(_ => _.AppStatus)
            .IncludeField(_ => _.Content)
            .IncludeField(_ => _.EmbedData)
            .IncludeField(_ => _.EmbedUrl)
            .IncludeField(_ => _.IsPaid)
            .IncludeField(_ => _.IsPublic)
            .IncludeField(_ => _.Tiers)
            .IncludeField(_ => _.PublishedAt)
            .IncludeField(_ => _.Title)
            .IncludeField(_ => _.Url)
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPosts.Data.All(_ => _.Type == "post"));
    }

    [TestMethod]
    public async Task CampaignPosts_Full_IncludeAllFields()
    {
        // Act
        var campaignPosts = await PatreonAPIv2.CampaignPosts(AppSettingsProvider.CampaignId)
            .IncludeAllFields()
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPosts.Data.All(_ => _.Type == "post"));
    }
}
