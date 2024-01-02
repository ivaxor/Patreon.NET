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
        Assert.IsNotNull(identity.Data.Attributes.Created);
        Assert.IsNotNull(identity.Data.Attributes.Email);
        Assert.IsNotNull(identity.Data.Attributes.Url);
        Assert.IsNotNull(identity.Links.Self);
    }

    [TestMethod]
    public async Task IdentityExtended()
    {
        // Act
        var identity = await PatreonAPIv2.Identity()
            .IncludeField(_ => _.Email)
            .IncludeField(_ => _.ImageUrl)
            .IncludeField(_ => _.ThumbUrl)
            .IncludeField(_ => _.Url)
            .ExecuteAsync();

        // Assert
        Assert.AreEqual("user", identity.Data.Type);
        Assert.IsNotNull(identity.Data.Attributes.Created);
        Assert.IsNotNull(identity.Data.Attributes.Email);
        Assert.IsNotNull(identity.Data.Attributes.Url);
        Assert.IsNotNull(identity.Links.Self);
    }

    [TestMethod]
    public async Task IdentityWithMemberships()
    {
        // Act
        var identity = await PatreonAPIv2.Identity()
            .Include("memberships")
            .ExecuteAsync();

        // Assert
        Assert.AreEqual("user", identity.Data.Type);
        Assert.IsNotNull(identity.Data.Attributes.Created);
        Assert.IsNotNull(identity.Data.Attributes.Email);
        Assert.IsNotNull(identity.Data.Attributes.Url);
        Assert.IsNotNull(identity.Links.Self);
    }
}
