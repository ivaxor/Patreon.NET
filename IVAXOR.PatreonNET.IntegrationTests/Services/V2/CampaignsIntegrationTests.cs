using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.Benefits;
using IVAXOR.PatreonNET.Models.Resources.Goals;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Sets.V2;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V2;

[TestClass]
public class CampaignsIntegrationTests
{
    protected PatreonAPIv2 PatreonAPIv2 { get; }

    public CampaignsIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonAppSettingsTokenManager();

        PatreonAPIv2 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task Campaigns()
    {
        // Act
        var response = await PatreonAPIv2.Campaigns().ExecuteAsync();
        var campaigns = new PatreonCampaignsV2Response(response);

        // Assert
        Assert.AreEqual(1, campaigns.Campaigns.Length);
    }

    [TestMethod]
    public async Task Campaigns_IncludeField_All()
    {
        // Act
        var response = await PatreonAPIv2.Campaigns()
            .IncludeField(_ => _.CreatedAt)
            .IncludeField(_ => _.CreationName)
            .IncludeField(_ => _.DiscordServerId)
            .IncludeField(_ => _.GoogleAnalyticsId)
            .IncludeField(_ => _.HasRss)
            .IncludeField(_ => _.HasSentRssNotify)
            .IncludeField(_ => _.ImageSmallUrl)
            .IncludeField(_ => _.ImageUrl)
            .IncludeField(_ => _.IsChargedImmediately)
            .IncludeField(_ => _.IsMonthly)
            .IncludeField(_ => _.IsNsfw)
            .IncludeField(_ => _.MainVideoEmbed)
            .IncludeField(_ => _.MainVideoUrl)
            .IncludeField(_ => _.OneLiner)
            .IncludeField(_ => _.PatronCount)
            .IncludeField(_ => _.PayPerName)
            .IncludeField(_ => _.PledgeUrl)
            .IncludeField(_ => _.PublishedAt)
            .IncludeField(_ => _.RssArtworkUrl)
            .IncludeField(_ => _.RssFeedTitle)
            .IncludeField(_ => _.ShowEarnings)
            .IncludeField(_ => _.Summary)
            .IncludeField(_ => _.ThanksEmbed)
            .IncludeField(_ => _.ThanksMsg)
            .IncludeField(_ => _.ThanksVideoUrl)
            .IncludeField(_ => _.Url)
            .IncludeField(_ => _.Vanity)
            .ExecuteAsync();
        var campaigns = new PatreonCampaignsV2Response(response);

        // Assert
        Assert.AreEqual(1, campaigns.Campaigns.Length);
    }

    [TestMethod]
    public async Task Campaigns_IncludeAllFields()
    {
        // Act
        var response = await PatreonAPIv2.Campaigns()
            .IncludeAllFields()
            .ExecuteAsync();
        var campaigns = new PatreonCampaignsV2Response(response);

        // Assert
        Assert.AreEqual(1, campaigns.Campaigns.Length);
    }

    [TestMethod]
    public async Task Campaigns_Include_IncludeAllFields_Tiers()
    {
        // Act
        var response = await PatreonAPIv2.Campaigns()
            .Include(PatreonTopLevelIncludes.V2.Campaigns.Tiers)
            .IncludeAllFields<PatreonTierAttributes>()
            .ExecuteAsync();
        var campaigns = new PatreonCampaignsV2Response(response);

        // Assert
        Assert.AreEqual(1, campaigns.Campaigns.Length);
    }

    [TestMethod]
    public async Task Campaigns_Include_IncludeAllFields_Creator()
    {
        // Act
        var response = await PatreonAPIv2.Campaigns()
            .Include(PatreonTopLevelIncludes.V2.Campaigns.Creator)
            .IncludeAllFields<PatreonUserV2Attributes>()
            .ExecuteAsync();
        var campaigns = new PatreonCampaignsV2Response(response);

        // Assert
        Assert.AreEqual(1, campaigns.Campaigns.Length);
    }

    [TestMethod]
    public async Task Campaigns_Include_IncludeAllFields_Benefits()
    {
        // Act
        var response = await PatreonAPIv2.Campaigns()
            .Include(PatreonTopLevelIncludes.V2.Campaigns.Benefits)
            .IncludeAllFields<PatreonBenefitAttributes>()
            .ExecuteAsync();
        var campaigns = new PatreonCampaignsV2Response(response);

        // Assert
        Assert.AreEqual(1, campaigns.Campaigns.Length);
    }

    [TestMethod]
    public async Task Campaigns_Include_IncludeAllFields_Goals()
    {
        // Act
        var response = await PatreonAPIv2.Campaigns()
            .Include(PatreonTopLevelIncludes.V2.Campaigns.Goals)
            .IncludeAllFields<PatreonGoalAttributes>()
            .ExecuteAsync();
        var campaigns = new PatreonCampaignsV2Response(response);

        // Assert
        Assert.AreEqual(1, campaigns.Campaigns.Length);
    }
}
