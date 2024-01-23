using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Sets;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V2;

[TestClass]
public class IdentityIntegrationTests
{
    protected PatreonAPIv2 PatreonAPIv2 { get; }

    public IdentityIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonAppSettingsTokenManager();

        PatreonAPIv2 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task Identity()
    {
        // Act
        var response = await PatreonAPIv2.Identity().ExecuteAsync();
        var identity = new PatreonIdenityV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)], response.Data.Type);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(identity.Identity);
    }

    [TestMethod]
    public async Task Identity_IncludeField()
    {
        // Act
        var response = await PatreonAPIv2.Identity()
            .IncludeField(_ => _.About)
            .IncludeField(_ => _.Created)
            .IncludeField(_ => _.Email)
            .IncludeField(_ => _.FirstName)
            .IncludeField(_ => _.FullName)
            .IncludeField(_ => _.ImageUrl)
            .IncludeField(_ => _.LastName)
            .IncludeField(_ => _.SocialConnections)
            .IncludeField(_ => _.ThumbUrl)
            .IncludeField(_ => _.Url)
            .IncludeField(_ => _.Vanity)
            .ExecuteAsync();
        var identity = new PatreonIdenityV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)], response.Data.Type);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(identity.Identity);
    }

    [TestMethod]
    public async Task Identity_IncludeAllFields()
    {
        // Act
        var response = await PatreonAPIv2.Identity()
            .IncludeAllFields()
            .ExecuteAsync();
        var identity = new PatreonIdenityV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)], response.Data.Type);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(identity.Identity);
    }

    [TestMethod]
    public async Task Identity_WithMemberships()
    {
        // Act
        var response = await PatreonAPIv2.Identity()
            .Include(PatreonTopLevelIncludes.V2.Identity.Memberships)
            .IncludeAllFields<PatreonMemberAttributes>()
            .ExecuteAsync();
        var identity = new PatreonIdenityV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)], response.Data.Type);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(identity.Identity);
    }

    /// <summary>
    /// Patreon API bug
    /// Throws 500 server internal error when some campaign fields are included
    /// </summary>
    [DataTestMethod]
    [DataRow(nameof(PatreonCampaignV2Attributes.DiscordServerId))]
    [DataRow(nameof(PatreonCampaignV2Attributes.ThanksEmbed))]
    [DataRow(nameof(PatreonCampaignV2Attributes.ThanksMsg))]
    [DataRow(nameof(PatreonCampaignV2Attributes.ThanksVideoUrl))]
    public async Task Identity_WithCampaign_Exception(string campaignPropertyName)
    {
        // Arrange
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)];
        var fieldName = typeof(PatreonCampaignV2Attributes).GetProperty(campaignPropertyName).GetCustomAttribute<JsonPropertyNameAttribute>().Name;
        var query = PatreonAPIv2.Identity()
            .Include(PatreonTopLevelIncludes.V2.Identity.Campaign)
            .IncludeField(resourceName, fieldName);

        // Act
        var exception = await Assert.ThrowsExceptionAsync<PatreonAPIException>(async () => await query.ExecuteAsync());

        // Assert
        Assert.AreEqual(500, exception.StatusCode);
    }

    [TestMethod]
    public async Task Identity_WithCampaign()
    {
        // Act
        var response = await PatreonAPIv2.Identity()
            .Include(PatreonTopLevelIncludes.V2.Identity.Campaign)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.CreatedAt)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.CreationName)
            //.IncludeField<PatreonCampaignV2Attributes>(_ => _.DiscordServerId)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.GoogleAnalyticsId)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.HasRss)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.HasSentRssNotify)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.ImageSmallUrl)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.ImageUrl)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.IsChargedImmediately)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.IsMonthly)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.IsNsfw)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.MainVideoEmbed)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.MainVideoUrl)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.OneLiner)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.PatronCount)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.PayPerName)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.PledgeUrl)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.PublishedAt)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.RssArtworkUrl)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.RssFeedTitle)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.ShowEarnings)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.Summary)
            //.IncludeField<PatreonCampaignV2Attributes>(_ => _.ThanksEmbed)
            //.IncludeField<PatreonCampaignV2Attributes>(_ => _.ThanksMsg)
            //.IncludeField<PatreonCampaignV2Attributes>(_ => _.ThanksVideoUrl)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.Url)
            .IncludeField<PatreonCampaignV2Attributes>(_ => _.Vanity)
            .ExecuteAsync();
        var identity = new PatreonIdenityV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)], response.Data.Type);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(identity.Identity);
        Assert.IsNotNull(identity.Campaign);
    }
}
