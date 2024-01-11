using IVAXOR.PatreonNET.Services.API;

namespace IVAXOR.PatreonNET.IntegrationTests.Services;

[TestClass]
public class PatreonAPIv2IntegrationTests
{
    protected readonly PatreonAPIv2 PatreonAPIv2;

    public PatreonAPIv2IntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonStubTokenManager();

        PatreonAPIv2 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task Identity()
    {
        // Act
        var identity = await PatreonAPIv2.Identity().ExecuteAsync();

        // Assert
        Assert.AreEqual("user", identity.Data.Type);
        Assert.IsNotNull(identity.Data.Id);
        Assert.IsNotNull(identity.Links.Self);
    }

    [TestMethod]
    public async Task Identity_IncludeField()
    {
        // Act
        var identity = await PatreonAPIv2.Identity()
            .IncludeField(_ => _.About)
            .IncludeField(_ => _.Created)
            .IncludeField(_ => _.Email)
            .IncludeField(_ => _.FirstName)
            .IncludeField(_ => _.FullName)
            .IncludeField(_ => _.ImageUrl)
            .IncludeField(_ => _.LastName)
            .IncludeField(_ => _.SocialConnections)
            .IncludeField(_ => _.ThumbUrl)
            .IncludeField(_ => _.Url)
            .IncludeField(_ => _.Vanity)
            .ExecuteAsync();

        // Assert
        Assert.AreEqual("user", identity.Data.Type);
        Assert.IsNotNull(identity.Data.Id);
        Assert.IsNotNull(identity.Data.Attributes.Created);
        Assert.IsNotNull(identity.Data.Attributes.Email);
        Assert.IsNotNull(identity.Data.Attributes.SocialConnections);
        Assert.IsNotNull(identity.Data.Attributes.Url);
        Assert.IsNotNull(identity.Links.Self);
    }

    [TestMethod]
    public async Task Identity_IncludeAllFields()
    {
        // Act
        var identity = await PatreonAPIv2.Identity()
            .IncludeAllFields()
            .ExecuteAsync();

        // Assert
        Assert.AreEqual("user", identity.Data.Type);
        Assert.IsNotNull(identity.Data.Id);
        Assert.IsNotNull(identity.Data.Attributes.Created);
        Assert.IsNotNull(identity.Data.Attributes.Email);
        Assert.IsNotNull(identity.Data.Attributes.SocialConnections);
        Assert.IsNotNull(identity.Data.Attributes.Url);
        Assert.IsNotNull(identity.Links.Self);
    }
}
