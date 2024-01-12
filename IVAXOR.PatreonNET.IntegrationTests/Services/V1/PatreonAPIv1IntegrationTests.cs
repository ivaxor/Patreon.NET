using IVAXOR.PatreonNET.Models.Resources.PledgeV1;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V1;

[TestClass]
public class PatreonAPIv1IntegrationTests
{
    protected HttpClient HttpClient { get; }
    protected IPatreonTokenManager TokenManager { get; }
    protected PatreonAPIv1 PatreonAPIv1 { get; }

    public PatreonAPIv1IntegrationTests()
    {
        HttpClient = new HttpClient();
        TokenManager = new PatreonStubTokenManager();

        PatreonAPIv1 = new(HttpClient, TokenManager);
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

    [TestMethod]
    public async Task CampaignPledges_ManualUrl()
    {
        // Arrange
        var url = "https://patreon.com/api/oauth2/api/campaigns/70261/pledges?page%5Bcount%5D=10&sort=created&page%5Bcursor%5D=2017-08-21T20%3A16%3A49.258893%2B00%3A00";
        var query = new PatreonAPIv1Query<PatreonResponseMulti<PatreonPledgeV1Attributes, PatreonPledgeV1Relationships>, PatreonPledgeV1Attributes, PatreonPledgeV1Relationships>(url, HttpClient, TokenManager);

        // Act
        var campaignPledges = await query.ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPledges.Data.All(_ => _.Type == "pledge"));
    }
}
