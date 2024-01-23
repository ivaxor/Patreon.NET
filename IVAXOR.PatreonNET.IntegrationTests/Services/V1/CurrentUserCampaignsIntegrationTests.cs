using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV1;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V1;

[TestClass]
public class CurrentUserCampaignsIntegrationTests
{
    protected PatreonAPIv1 PatreonAPIv1 { get; }

    public CurrentUserCampaignsIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonAppSettingsTokenManager();

        PatreonAPIv1 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task CurrentUserCampaigns()
    {
        // Act
        var currentUserCampaigns = await PatreonAPIv1.CurrentUserCampaigns().ExecuteAsync();

        // Assert
        Assert.IsTrue(currentUserCampaigns.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV1Attributes)]));
    }

    [TestMethod]
    public async Task CurrentUserCampaigns_Include_All()
    {
        // Act
        var currentUserCampaigns = await PatreonAPIv1.CurrentUserCampaigns()
            .Include(PatreonTopLevelIncludes.V1.CurrentUserCampaigns.Creator)
            .Include(PatreonTopLevelIncludes.V1.CurrentUserCampaigns.Goals)
            .Include(PatreonTopLevelIncludes.V1.CurrentUserCampaigns.Rewards)
            .Include(PatreonTopLevelIncludes.V1.CurrentUserCampaigns.Pledges)
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(currentUserCampaigns.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV1Attributes)]));
    }
}
