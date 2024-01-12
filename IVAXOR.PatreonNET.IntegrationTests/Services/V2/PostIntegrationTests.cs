namespace IVAXOR.PatreonNET.IntegrationTests.Services.V2;

[TestClass]
public class PostIntegrationTests
{
    protected PatreonAPIv2 PatreonAPIv2 { get; }

    public PostIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonStubTokenManager();

        PatreonAPIv2 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task Post()
    {
        // Act
        var post = await PatreonAPIv2.Post(AppSettingsProvider.PostId).ExecuteAsync();

        // Assert
        Assert.AreEqual("post", post.Data.Type);
        Assert.IsNotNull(post.Data.Id);
        Assert.IsNotNull(post.Links.Self);
    }

    [TestMethod]
    public async Task Post_Full_IncludeField()
    {
        // Act
        var post = await PatreonAPIv2.Post(AppSettingsProvider.PostId)
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

        // Assert
        Assert.AreEqual("post", post.Data.Type);
        Assert.IsNotNull(post.Data.Id);
        Assert.IsNotNull(post.Links.Self);
    }

    [TestMethod]
    public async Task Post_Full_IncludeAllFields()
    {
        // Act
        var post = await PatreonAPIv2.Post(AppSettingsProvider.PostId)
            .IncludeAllFields()
            .ExecuteAsync();

        // Assert
        Assert.AreEqual("post", post.Data.Type);
        Assert.IsNotNull(post.Data.Id);
        Assert.IsNotNull(post.Links.Self);
    }
}
