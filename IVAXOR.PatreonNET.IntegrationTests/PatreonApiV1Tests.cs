using IVAXOR.PatreonNET.IntegrationTests.Stubs;
using IVAXOR.PatreonNET.Services;

namespace IVAXOR.PatreonNET.IntegrationTests;

[TestClass]
public class PatreonApiV1Tests
{
    private readonly PatreonApiV1 PatreonAPI;

    public PatreonApiV1Tests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonStubTokenManager();

        PatreonAPI = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task GetCurrentUserAsync()
    {
        // Arrange
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
        // Arrange
        var currentUserCampaigns = await PatreonAPI.GetCurrentUserCampaignsAsync();

        // Assert
        Assert.AreEqual("campaign", currentUserCampaigns.Data.Single().Type);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.CreatedAt);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.Url);
        Assert.IsNotNull(currentUserCampaigns.Data.Single().Attributes.PledgeUrl);        
    }
}
