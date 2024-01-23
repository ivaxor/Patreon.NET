using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Sets;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V2;

[TestClass]
public class CampaignPostsIntegrationTests
{
    protected PatreonAPIv2 PatreonAPIv2 { get; }

    public CampaignPostsIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonAppSettingsTokenManager();

        PatreonAPIv2 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task CampaignPosts()
    {
        // Act
        var response = await PatreonAPIv2.CampaignPosts(AppSettingsProvider.CampaignId).ExecuteAsync();
        var campaignPosts = new PatreonPostsV2Response(response);

        // Assert
        Assert.IsTrue(campaignPosts.Posts.Any());
    }

    [TestMethod]
    public async Task CampaignPosts_IncludeField()
    {
        // Act
        var response = await PatreonAPIv2.CampaignPosts(AppSettingsProvider.CampaignId)
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
        var campaignPosts = new PatreonPostsV2Response(response);

        // Assert
        Assert.IsTrue(campaignPosts.Posts.Any());
    }

    [TestMethod]
    public async Task CampaignPosts_IncludeAllFields()
    {
        // Act
        var response = await PatreonAPIv2.CampaignPosts(AppSettingsProvider.CampaignId)
            .IncludeAllFields()
            .ExecuteAsync();
        var campaignPosts = new PatreonPostsV2Response(response);

        // Assert
        Assert.IsTrue(campaignPosts.Posts.Any());
    }

    [TestMethod]
    public async Task CampaignPosts_WithCampaign()
    {
        // Act
        var response = await PatreonAPIv2.CampaignPosts(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.CampaignPosts.Campaign)
            .IncludeAllFields<PatreonCampaignV2Attributes>()            
            .ExecuteAsync();
        var campaignPosts = new PatreonPostsV2Response(response);

        // Assert
        Assert.IsTrue(campaignPosts.Posts.Any());
        Assert.IsTrue(campaignPosts.Posts.All(_ => _.Campaign != null));
    }

    [TestMethod]
    public async Task CampaignPosts_WithUser()
    {
        // Act
        var response = await PatreonAPIv2.CampaignPosts(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.CampaignPosts.User)
            .IncludeAllFields<PatreonUserV2Attributes>()
            .ExecuteAsync();
        var campaignPosts = new PatreonPostsV2Response(response);

        // Assert
        Assert.IsTrue(campaignPosts.Posts.Any());
        Assert.IsTrue(campaignPosts.Posts.All(_ => _.User != null));
    }
}
