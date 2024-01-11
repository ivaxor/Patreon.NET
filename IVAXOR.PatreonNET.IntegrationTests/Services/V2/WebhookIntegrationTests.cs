using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Services.API;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V2;

[TestClass]
public class WebhookIntegrationTests
{
    protected PatreonAPIv2 PatreonAPIv2 { get; }

    public WebhookIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonStubTokenManager();

        PatreonAPIv2 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task Webhooks()
    {
        // Act
        var webhooks = await PatreonAPIv2.Webhooks().ExecuteAsync();

        // Assert
        Assert.IsTrue(webhooks.Data.All(_ => _.Type == "webhook"));
    }

    [TestMethod]
    public async Task Webhooks_Full_IncludeField()
    {
        // Act
        var webhooks = await PatreonAPIv2.Webhooks()
            .IncludeField(_ => _.LastAttemptedAt)
            .IncludeField(_ => _.NumConsecutiveTimesFailed)
            .IncludeField(_ => _.Paused)
            .IncludeField(_ => _.Secret)
            .IncludeField(_ => _.Triggers)
            .IncludeField(_ => _.Uri)
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(webhooks.Data.All(_ => _.Type == "webhook"));
    }

    [TestMethod]
    public async Task Webhooks_Full_IncludeAllFields()
    {
        // Act
        var webhooks = await PatreonAPIv2.Webhooks()
            .IncludeAllFields()
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(webhooks.Data.All(_ => _.Type == "webhook"));
    }

    /// <summary>
    /// No documentation on how to query client fields
    /// </summary>
    [TestMethod]
    public async Task Webhooks_WithClient()
    {
        // Act
        var webhooks = await PatreonAPIv2.Webhooks()
            .Include("client")
            //.IncludeAllFields<PatreonOAuthClientAttributes>()
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(webhooks.Data.All(_ => _.Type == "webhook"));
    }

    [TestMethod]
    public async Task Webhooks_WithCampaign()
    {
        // Act
        var webhooks = await PatreonAPIv2.Webhooks()
            .Include("campaign")
            .IncludeAllFields<PatreonCampaignV2Attributes>()
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(webhooks.Data.All(_ => _.Type == "webhook"));
    }
}
