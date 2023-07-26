namespace IVAXOR.PatreonNET.IntegrationTests.Services;

[TestClass]
public class PatreonApiV1IntegrationTests
{
    private readonly PatreonApiV1 PatreonAPI;

    public PatreonApiV1IntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonStubTokenManager();

        PatreonAPI = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task GetCurrentUserAsync()
    {
        // Act
        var currentUser = await PatreonAPI.GetCurrentUserAsync();

        // Assert
        Assert.AreEqual("user", currentUser.Data.Type);
        Assert.IsNotNull(currentUser.Data.Attributes.Created);
        Assert.IsNotNull(currentUser.Data.Attributes.Email);
        Assert.IsNotNull(currentUser.Data.Attributes.Url);
        Assert.IsNotNull(currentUser.Links.Self);
    }

    [TestMethod]
    public async Task GetCurrentUserCampaignsAsync()
    {
        // Act
        var currentUserCampaigns = await PatreonAPI.GetCurrentUserCampaignsAsync();

        // Assert
        Assert.AreEqual("campaign", currentUserCampaigns.Data.Single().Type);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.CreatedAt);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.Url);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.PledgeUrl);
    }

    [TestMethod]
    [DataRow("rewards")]
    [DataRow("creator")]
    [DataRow("goals")]
    [DataRow("pledges")]
    public async Task GetCurrentUserCampaignsAsync_SingleInclude(string include)
    {
        // Arrange
        var includes = new string[] { include };

        // Act
        var currentUserCampaigns = await PatreonAPI.GetCurrentUserCampaignsAsync();

        // Assert
        Assert.AreEqual("campaign", currentUserCampaigns.Data.Single().Type);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.CreatedAt);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.Url);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.PledgeUrl);
    }

    [TestMethod]
    public async Task GetCurrentUserCampaignsAsync_AllInclude()
    {
        // Arrange
        var includes = AvailableIncludes.V1CurrentUsercampaigns;

        // Act
        var currentUserCampaigns = await PatreonAPI.GetCurrentUserCampaignsAsync(includes);

        // Assert
        Assert.AreEqual("campaign", currentUserCampaigns.Data.Single().Type);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.CreatedAt);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.Url);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.PledgeUrl);
    }
}
