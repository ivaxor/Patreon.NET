using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.Benefits;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Deliverables;
using IVAXOR.PatreonNET.Models.Resources.Goals;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Sets;

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
        var response = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId).ExecuteAsync();
        var campaign = new PatreonCampaignV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.CampaignId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(campaign.Campaign);
    }

    [TestMethod]
    public async Task Campaign_Full_IncludeField()
    {
        // Act
        var response = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId)
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
        var campaign = new PatreonCampaignV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.CampaignId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(campaign.Campaign);
    }

    [TestMethod]
    public async Task Campaign_Full_IncludeAllFields()
    {
        // Act
        var response = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId)
            .IncludeAllFields()
            .ExecuteAsync();
        var campaign = new PatreonCampaignV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.CampaignId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(campaign.Campaign);
    }

    [TestMethod]
    public async Task Campaign_WithBenefits_WithBenefitsTiers()
    {
        // Act
        var response = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Campaigns.Benefits)
            .Include(PatreonTopLevelIncludes.V2.Campaigns.BenefitsTiers)
            .IncludeAllFields<PatreonBenefitAttributes>()
            .ExecuteAsync();
        var campaign = new PatreonCampaignV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.CampaignId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(campaign.Campaign);
        Assert.IsTrue(campaign.Benefits.Any());
        Assert.IsTrue(campaign.TiersBenefits.Any());
    }

    [TestMethod]
    public async Task Campaign_WithBenefits_WithBenefitsDeliverables()
    {
        // Act
        var response = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Campaigns.Benefits)
            .Include(PatreonTopLevelIncludes.V2.Campaigns.BenefitsDeliverables)
            .IncludeAllFields<PatreonBenefitAttributes>()
            .IncludeAllFields<PatreonDeliverableAttributes>()
            .ExecuteAsync();
        var campaign = new PatreonCampaignV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.CampaignId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(campaign.Campaign);
        Assert.IsTrue(campaign.Benefits.Any());
    }

    /// <summary>
    /// TODO: Investigate
    /// </summary>
    [TestMethod]
    public async Task Campaign_WithCategories()
    {
        // Act
        var response = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Campaigns.Categories)
            .ExecuteAsync();
        var campaign = new PatreonCampaignV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.CampaignId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(campaign.Campaign);
    }

    [TestMethod]
    public async Task Campaign_WithCreator()
    {
        // Act
        var response = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Campaigns.Creator)
            .IncludeAllFields<PatreonUserV2Attributes>()
            .ExecuteAsync();
        var campaign = new PatreonCampaignV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.CampaignId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(campaign.Campaign);
        Assert.IsNotNull(campaign.Creator);
    }

    [TestMethod]
    public async Task Campaign_WithTiers_WithTiersBenefits()
    {
        // Act
        var response = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Campaigns.Tiers)
            .Include(PatreonTopLevelIncludes.V2.Campaigns.TiersBenefits)
            .IncludeAllFields<PatreonTierAttributes>()
            .ExecuteAsync();
        var campaign = new PatreonCampaignV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.CampaignId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(campaign.Campaign);
        Assert.IsTrue(campaign.Tiers.Any());
        Assert.IsTrue(campaign.TiersBenefits.Any());
    }

    /// <summary>
    /// The Goals feature has been removed from Patreon.
    /// https://support.patreon.com/hc/en-us/articles/203913409-How-to-set-Goals-for-your-page
    /// </summary>
    [TestMethod]
    public async Task Campaign_WithGoals()
    {
        // Act
        var response = await PatreonAPIv2.Campaign(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Campaigns.Goals)
            .IncludeAllFields<PatreonGoalAttributes>()
            .ExecuteAsync();
        var campaign = new PatreonCampaignV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.CampaignId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(campaign.Campaign);
        Assert.IsFalse(campaign.Goals.Any());
    }
}
