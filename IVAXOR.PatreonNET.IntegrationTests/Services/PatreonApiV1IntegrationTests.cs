namespace IVAXOR.PatreonNET.IntegrationTests.Services;

[TestClass]
public class PatreonAPIv1IntegrationTests
{
    protected readonly PatreonAPIv1 PatreonAPI;

    public PatreonAPIv1IntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonStubTokenManager();

        PatreonAPI = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task GetCurrentUser()
    {
        // Act
        var currentUser = await PatreonAPI.GetCurrentUser().ExecuteAsync();

        // Assert
        Assert.AreEqual("user", currentUser.Data.Type);
        Assert.IsNotNull(currentUser.Data.Attributes.Created);
        Assert.IsNotNull(currentUser.Data.Attributes.Email);
        Assert.IsNotNull(currentUser.Data.Attributes.Url);
        Assert.IsNotNull(currentUser.Links.Self);
    }

    [TestMethod]
    public async Task GetCurrentUserCampaigns()
    {
        // Act
        var currentUserCampaigns = await PatreonAPI.GetCurrentUserCampaigns().ExecuteAsync();

        // Assert
        Assert.AreEqual("campaign", currentUserCampaigns.Data.Single().Type);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.CreatedAt);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.Url);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.PledgeUrl);
    }
}
