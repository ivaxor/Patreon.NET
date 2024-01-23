using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.PledgeV1;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V1;

[TestClass]
public class CampaignPledgesIntegrationTests
{
    protected HttpClient HttpClient { get; } = new();
    protected IPatreonTokenManager TokenManager { get; } = new PatreonAppSettingsTokenManager();
    protected PatreonAPIv1 PatreonAPIv1 { get; }

    public CampaignPledgesIntegrationTests()
    {
        PatreonAPIv1 = new(HttpClient, TokenManager);
    }

    [TestMethod]
    public async Task CampaignPledges()
    {
        // Act
        var campaignPledges = await PatreonAPIv1.CampaignPledges(AppSettingsProvider.CampaignId).ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPledges.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPledgeV1Attributes)]));
    }

    [TestMethod]
    public async Task CampaignPledges_Include_All()
    {
        // Act
        var campaignPledges = await PatreonAPIv1.CampaignPledges(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V1.CampaignPledges.Address)
            .Include(PatreonTopLevelIncludes.V1.CampaignPledges.Creator)
            .Include(PatreonTopLevelIncludes.V1.CampaignPledges.Patron)
            .Include(PatreonTopLevelIncludes.V1.CampaignPledges.Reward)
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPledges.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPledgeV1Attributes)]));
    }

    [TestMethod]
    public async Task CampaignPledges_ManualUrl()
    {
        // Arrange
        var url = $"https://patreon.com/api/oauth2/api/campaigns/{AppSettingsProvider.CampaignId}/pledges?page%5Bcount%5D=10&sort=created&page%5Bcursor%5D=2017-08-21T20%3A16%3A49.258893%2B00%3A00";
        var query = new PatreonAPIQuery<PatreonRawResponseMulti<PatreonPledgeV1Attributes, PatreonPledgeV1Relationships>, PatreonPledgeV1Attributes, PatreonPledgeV1Relationships>(url, HttpClient, TokenManager);

        // Act
        var campaignPledges = await query.ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPledges.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPledgeV1Attributes)]));
    }
}
