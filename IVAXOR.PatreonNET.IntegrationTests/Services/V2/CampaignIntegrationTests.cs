using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.Benefits;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Goals;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V2;

[TestClass]
public class CampaignIntegrationTests
{
    protected PatreonAPIv2 PatreonAPIv2 { get; }

    public CampaignIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonAppSettingsTokenManager();

        PatreonAPIv2 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task Campaign()
    {
        // Act
        var campaign = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId).ExecuteAsync();

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], campaign.Data.Type);
        Assert.IsNotNull(campaign.Data.Id);
        Assert.IsNotNull(campaign.Links.Self);
    }

    [TestMethod]
    public async Task Campaign_Full_IncludeField()
    {
        // Act
        var campaign = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId)
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

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], campaign.Data.Type);
        Assert.IsNotNull(campaign.Data.Id);
        Assert.IsNotNull(campaign.Links.Self);
    }

    [TestMethod]
    public async Task Campaign_Full_IncludeAllFields()
    {
        // Act
        var campaign = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId)
            .IncludeAllFields()
            .ExecuteAsync();

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], campaign.Data.Type);
        Assert.IsNotNull(campaign.Data.Id);
        Assert.IsNotNull(campaign.Links.Self);
    }

    [TestMethod]
    public async Task Campaign_WithTiers()
    {
        // Act
        var campaign = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Campaigns.Tiers)
            .IncludeAllFields<PatreonTierAttributes>()
            .ExecuteAsync();

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], campaign.Data.Type);
        Assert.IsNotNull(campaign.Data.Id);
        Assert.IsNotNull(campaign.Links.Self);
    }

    [TestMethod]
    public async Task Campaign_WithCreator()
    {
        // Act
        var campaign = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Campaigns.Creator)
            .IncludeAllFields<PatreonUserV2Attributes>()
            .ExecuteAsync();

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], campaign.Data.Type);
        Assert.IsNotNull(campaign.Data.Id);
        Assert.IsNotNull(campaign.Links.Self);
    }

    [TestMethod]
    public async Task Campaign_WithBenefits()
    {
        // Act
        var campaign = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Campaigns.Benefits)
            .IncludeAllFields<PatreonBenefitAttributes>()
            .ExecuteAsync();

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], campaign.Data.Type);
        Assert.IsNotNull(campaign.Data.Id);
        Assert.IsNotNull(campaign.Links.Self);
    }

    [TestMethod]
    public async Task Campaign_WithGoals()
    {
        // Act
        var campaign = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Campaigns.Goals)
            .IncludeAllFields<PatreonGoalAttributes>()
            .ExecuteAsync();

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], campaign.Data.Type);
        Assert.IsNotNull(campaign.Data.Id);
        Assert.IsNotNull(campaign.Links.Self);
    }
}
