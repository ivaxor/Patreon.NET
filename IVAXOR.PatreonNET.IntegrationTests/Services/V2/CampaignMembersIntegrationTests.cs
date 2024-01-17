using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.Addresses;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;

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
        var campaignMembers = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId).ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignMembers.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonMemberAttributes)]));
    }

    [TestMethod]
    public async Task CampaignMembers_Full_IncludeField()
    {
        // Act
        var campaignMembers = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId)
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

        // Assert
        Assert.IsTrue(campaignMembers.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonMemberAttributes)]));
    }

    [TestMethod]
    public async Task CampaignMembers_Full_IncludeAllFields()
    {
        // Act
        var campaignMembers = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId)
            .IncludeAllFields()
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignMembers.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonMemberAttributes)]));
    }

    [TestMethod]
    public async Task CampaignMembers_WithAddress()
    {
        // Act
        var campaignMembers = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Members.Address)
            .IncludeAllFields<PatreonAddressAttributes>()
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignMembers.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonMemberAttributes)]));
    }

    [TestMethod]
    public async Task CampaignMembers_WithCampaign()
    {
        // Act
        var campaignMembers = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Members.Campaign)
            .IncludeAllFields<PatreonCampaignV2Attributes>()
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignMembers.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonMemberAttributes)]));
    }

    [TestMethod]
    public async Task CampaignMembers_WithCurrentlyEntitledTiers()
    {
        // Act
        var campaignMembers = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Members.CurrentlyEntitledTiers)
            .IncludeAllFields<PatreonTierAttributes>()
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignMembers.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonMemberAttributes)]));
    }

    [TestMethod]
    public async Task CampaignMembers_WithUser()
    {
        // Act
        var campaignMembers = await PatreonAPIv2.CampaignMembers(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V2.Members.User)
            .IncludeAllFields<PatreonUserV2Attributes>()
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignMembers.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonMemberAttributes)]));
    }
}
