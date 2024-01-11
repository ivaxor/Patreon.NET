using IVAXOR.PatreonNET.Services.API;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V1;

[TestClass]
public class PatreonAPIv1IntegrationTests
{
    protected PatreonAPIv1 PatreonAPIv1 { get; }

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
        Assert.IsTrue(currentUserCampaigns.Data.All(_ => _.Type == "campaign"));
    }

    [TestMethod]
    public async Task CampaignPledges()
    {
        // Act
        var campaignPledges = await PatreonAPIv1.CampaignPledges(AppSettingsProvider.CampaignId).ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPledges.Data.All(_ => _.Type == "pledge"));
    }
}
