using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.PostsV1;
using IVAXOR.PatreonNET.Models.Responses.Sets.V1;

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
        var response = await PatreonAPIv1.CampaignPosts(AppSettingsProvider.CampaignId).ExecuteAsync();
        var posts = new PatreonPostsV1Reponse(response);

        // Assert
        Assert.IsTrue(response.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPostV1Attributes)]));
    }

    [TestMethod]
    public async Task CampaignPosts_Include_All()
    {
        // Act
        var response = await PatreonAPIv1.CampaignPosts(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Attachments)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Campaign)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.ContentLocks)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Comments)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Likes)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.User)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.UserDefinedTags)
            .ExecuteAsync();
        var posts = new PatreonPostsV1Reponse(response);

        // Assert
        Assert.IsTrue(response.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPostV1Attributes)]));
    }
}
