using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.PostsV1;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V1;

[TestClass]
public class CampaignPostsIntegrationTests
{
    protected PatreonAPIv1 PatreonAPIv1 { get; }

    public CampaignPostsIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonAppSettingsTokenManager();

        PatreonAPIv1 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task CampaignPosts()
    {
        // Act
        var campaignPosts = await PatreonAPIv1.CampaignPosts(AppSettingsProvider.CampaignId).ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPosts.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPostV1Attributes)]));
    }

    [TestMethod]
    public async Task CampaignPosts_Include()
    {
        // Act
        var campaignPosts = await PatreonAPIv1.CampaignPosts(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Attachments)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Campaign)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.ContentLocks)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Comments)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Likes)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.User)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.UserDefinedTags)
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPosts.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPostV1Attributes)]));
    }
}
