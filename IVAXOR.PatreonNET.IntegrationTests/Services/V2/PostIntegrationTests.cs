using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.PostsV2;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Sets.V2;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V2;

[TestClass]
public class PostIntegrationTests
{
    protected PatreonAPIv2 PatreonAPIv2 { get; }

    public PostIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonAppSettingsTokenManager();

        PatreonAPIv2 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task Post()
    {
        // Act
        var response = await PatreonAPIv2.Post(AppSettingsProvider.PostId).ExecuteAsync();
        var post = new PatreonPostV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPostV2Attributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.PostId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(post.Post);
    }

    [TestMethod]
    public async Task Post_IncludeField_All()
    {
        // Act
        var response = await PatreonAPIv2.Post(AppSettingsProvider.PostId)
            .IncludeField(_ => _.AppId)
            .IncludeField(_ => _.AppStatus)
            .IncludeField(_ => _.Content)
            .IncludeField(_ => _.EmbedData)
            .IncludeField(_ => _.EmbedUrl)
            .IncludeField(_ => _.IsPaid)
            .IncludeField(_ => _.IsPublic)
            .IncludeField(_ => _.Tiers)
            .IncludeField(_ => _.PublishedAt)
            .IncludeField(_ => _.Url)
            .ExecuteAsync();
        var post = new PatreonPostV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPostV2Attributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.PostId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(post.Post);
    }

    [TestMethod]
    public async Task Post_IncludeAllFields()
    {
        // Act
        var response = await PatreonAPIv2.Post(AppSettingsProvider.PostId)
            .IncludeAllFields()
            .ExecuteAsync();
        var post = new PatreonPostV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPostV2Attributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.PostId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(post.Post);
    }

    [TestMethod]
    public async Task Post_Include_IncludeAllFields_User()
    {
        // Act
        var response = await PatreonAPIv2.Post(AppSettingsProvider.PostId)
            .Include(PatreonTopLevelIncludes.V2.Posts.User)
            .IncludeAllFields<PatreonUserV2Attributes>()
            .ExecuteAsync();
        var post = new PatreonPostV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPostV2Attributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.PostId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(post.Post);
        Assert.IsNotNull(post.User);
    }

    [TestMethod]
    public async Task Post_Include_IncludeAllFields_Campaign()
    {
        // Act
        var response = await PatreonAPIv2.Post(AppSettingsProvider.PostId)
            .Include(PatreonTopLevelIncludes.V2.Posts.Campaign)
            .IncludeAllFields<PatreonCampaignV2Attributes>()
            .ExecuteAsync();
        var post = new PatreonPostV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPostV2Attributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.PostId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(post.Post);
        Assert.IsNotNull(post.Campaign);
    }
}
