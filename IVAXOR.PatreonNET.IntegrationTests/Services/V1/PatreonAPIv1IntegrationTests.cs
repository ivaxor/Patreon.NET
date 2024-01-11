using IVAXOR.PatreonNET.Services.API;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V1;

[TestClass]
public class PatreonAPIv1IntegrationTests
{
    protected readonly PatreonAPIv1 PatreonAPIv1;

    public PatreonAPIv1IntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonStubTokenManager();

        PatreonAPIv1 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task CurrentUser()
    {
        // Act
        var currentUser = await PatreonAPIv1.CurrentUser().ExecuteAsync();

        // Assert
        Assert.AreEqual("user", currentUser.Data.Type);
        Assert.IsNotNull(currentUser.Data.Attributes.Created);
        Assert.IsNotNull(currentUser.Data.Attributes.Email);
        Assert.IsNotNull(currentUser.Data.Attributes.Url);
        Assert.IsNotNull(currentUser.Links.Self);
    }

    [TestMethod]
    public async Task CurrentUserCampaigns()
    {
        // Act
        var currentUserCampaigns = await PatreonAPIv1.CurrentUserCampaigns().ExecuteAsync();

        // Assert
        Assert.AreEqual("campaign", currentUserCampaigns.Data.Single().Type);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.CreatedAt);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.Url);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.PledgeUrl);
    }
}
