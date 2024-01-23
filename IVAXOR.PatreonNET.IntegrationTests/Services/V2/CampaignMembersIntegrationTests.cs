using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.Addresses;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.PledgeEventsV2;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Sets.V2;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V2;

[TestClass]
public class CampaignMembersIntegrationTests
{
    protected PatreonAPIv2 PatreonAPIv2 { get; }

    public CampaignMembersIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonAppSettingsTokenManager();

        PatreonAPIv2 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task CampaignMembers()
    {
        // Act
        var response = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId).ExecuteAsync();
        var campaignMembers = new PatreonMembershipsV2Response(response);

        // Assert
        Assert.IsTrue(campaignMembers.Members.Any());
    }

    [TestMethod]
    public async Task CampaignMembers_IncludeField()
    {
        // Act
        var response = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId)
            .IncludeField(_ => _.CampaignLifetimeSupportCents)
            .IncludeField(_ => _.CurrentlyEntitledAmountCents)
            .IncludeField(_ => _.Email)
            .IncludeField(_ => _.FullName)
            .IncludeField(_ => _.IsFollower)
            .IncludeField(_ => _.LastChargeDate)
            .IncludeField(_ => _.LastChargeStatus)
            .IncludeField(_ => _.LifetimeSupportCents)
            .IncludeField(_ => _.NextChargeDate)
            .IncludeField(_ => _.Note)
            .IncludeField(_ => _.PatronStatus)
            .IncludeField(_ => _.PledgeCadence)
            .IncludeField(_ => _.PledgeRelationshipStart)
            .IncludeField(_ => _.WillPayAmountCents)
            .ExecuteAsync();
        var campaignMembers = new PatreonMembershipsV2Response(response);

        // Assert
        Assert.IsTrue(campaignMembers.Members.Any());
    }

    [TestMethod]
    public async Task CampaignMembers_IncludeAllFields()
    {
        // Act
        var response = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId)
            .IncludeAllFields()
            .ExecuteAsync();
        var campaignMembers = new PatreonMembershipsV2Response(response);

        // Assert
        Assert.IsTrue(campaignMembers.Members.Any());
    }

    [TestMethod]
    public async Task CampaignMembers_WithAddress()
    {
        // Act
        var response = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Members.Address)
            .IncludeAllFields<PatreonAddressAttributes>()
            .ExecuteAsync();
        var campaignMembers = new PatreonMembershipsV2Response(response);

        // Assert
        Assert.IsTrue(campaignMembers.Members.Any());
    }

    [TestMethod]
    public async Task CampaignMembers_WithCampaign()
    {
        // Act
        var response = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Members.Campaign)
            .IncludeAllFields<PatreonCampaignV2Attributes>()
            .ExecuteAsync();
        var campaignMembers = new PatreonMembershipsV2Response(response);

        // Assert
        Assert.IsTrue(campaignMembers.Members.Any());
        Assert.IsTrue(campaignMembers.Members.All(_ => _.Campaign != null));
    }

    [TestMethod]
    public async Task CampaignMembers_WithCurrentlyEntitledTiers()
    {
        // Act
        var response = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Members.CurrentlyEntitledTiers)
            .IncludeAllFields<PatreonTierAttributes>()
            .ExecuteAsync();
        var campaignMembers = new PatreonMembershipsV2Response(response);

        // Assert
        Assert.IsTrue(campaignMembers.Members.Any());
        Assert.IsTrue(campaignMembers.Members.All(_ => _.CurrentlyEntitledTiers != null));
    }

    [TestMethod]
    public async Task CampaignMembers_WithPledgeHistory()
    {
        // Act
        var response = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Members.PledgeHistory)
            .IncludeAllFields<PatreonPledgeEventV2Attributes>()
            .ExecuteAsync();
        var campaignMembers = new PatreonMembershipsV2Response(response);

        // Assert
        Assert.IsTrue(campaignMembers.Members.Any());
        Assert.IsTrue(campaignMembers.Members.All(_ => _.PledgeHistory != null));
    }

    [TestMethod]
    public async Task CampaignMembers_WithUser()
    {
        // Act
        var response = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Members.User)
            .IncludeAllFields<PatreonUserV2Attributes>()
            .ExecuteAsync();
        var campaignMembers = new PatreonMembershipsV2Response(response);

        // Assert
        Assert.IsTrue(campaignMembers.Members.Any());
        Assert.IsTrue(campaignMembers.Members.All(_ => _.User != null));
    }
}
