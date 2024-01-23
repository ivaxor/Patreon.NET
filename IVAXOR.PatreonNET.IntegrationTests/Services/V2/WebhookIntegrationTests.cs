using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Webhooks;
using IVAXOR.PatreonNET.Models.Responses.Sets;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V2;

[TestClass]
public class WebhookIntegrationTests
{
    protected PatreonAPIv2 PatreonAPIv2 { get; }

    public WebhookIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonAppSettingsTokenManager();

        PatreonAPIv2 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task Webhooks()
    {
        // Act
        var response = await PatreonAPIv2.Webhooks().ExecuteAsync();
        var webhooks = new PatreonWebhooksV2Response(response);

        // Assert
        Assert.IsTrue(response.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonWebhookAttributes)]));
    }

    [TestMethod]
    public async Task Webhooks_Full_IncludeField()
    {
        // Act
        var response = await PatreonAPIv2.Webhooks()
            .IncludeField(_ => _.LastAttemptedAt)
            .IncludeField(_ => _.NumConsecutiveTimesFailed)
            .IncludeField(_ => _.Paused)
            .IncludeField(_ => _.Secret)
            .IncludeField(_ => _.Triggers)
            .IncludeField(_ => _.Uri)
            .ExecuteAsync();
        var webhooks = new PatreonWebhooksV2Response(response);

        // Assert
        Assert.IsTrue(response.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonWebhookAttributes)]));
    }

    [TestMethod]
    public async Task Webhooks_Full_IncludeAllFields()
    {
        // Act
        var response = await PatreonAPIv2.Webhooks()
            .IncludeAllFields()
            .ExecuteAsync();
        var webhooks = new PatreonWebhooksV2Response(response);

        // Assert
        Assert.IsTrue(response.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonWebhookAttributes)]));
    }

    /// <summary>
    /// No documentation on how to query client fields
    /// </summary>
    [TestMethod]
    public async Task Webhooks_WithClient()
    {
        // Act
        var response = await PatreonAPIv2.Webhooks()
            .Include(PatreonTopLevelIncludes.V2.Webhooks.Client)
            .ExecuteAsync();
        var webhooks = new PatreonWebhooksV2Response(response);

        // Assert
        Assert.IsTrue(response.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonWebhookAttributes)]));
    }

    [TestMethod]
    public async Task Webhooks_WithCampaign()
    {
        // Act
        var response = await PatreonAPIv2.Webhooks()
            .Include(PatreonTopLevelIncludes.V2.Webhooks.Campaign)
            .IncludeAllFields<PatreonCampaignV2Attributes>()
            .ExecuteAsync();
        var webhooks = new PatreonWebhooksV2Response(response);

        // Assert
        Assert.IsTrue(response.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonWebhookAttributes)]));
    }
}
