using IVAXOR.PatreonNET.Constants;
using IVAXOR.PatreonNET.Models.Resources.Addresses;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Services.API;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V2;

[TestClass]
public class MemberIntegrationTests
{
    protected PatreonAPIv2 PatreonAPIv2 { get; }

    public MemberIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonStubTokenManager();

        PatreonAPIv2 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task Member()
    {
        // Act
        var member = await PatreonAPIv2.Member(AppSettingsProvider.MemberId).ExecuteAsync();

        // Assert
        Assert.AreEqual("member", member.Data.Type);
        Assert.IsNotNull(member.Data.Id);
        Assert.IsNotNull(member.Links.Self);
    }

    [TestMethod]
    public async Task Member_Full_IncludeField()
    {
        // Act
        var member = await PatreonAPIv2.Member(AppSettingsProvider.MemberId)
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
        Assert.AreEqual("member", member.Data.Type);
        Assert.IsNotNull(member.Data.Id);
        Assert.IsNotNull(member.Links.Self);
    }

    [TestMethod]
    public async Task Member_Full_IncludeAllFields()
    {
        // Act
        var member = await PatreonAPIv2.Member(AppSettingsProvider.MemberId)
            .IncludeAllFields()
            .ExecuteAsync();

        // Assert
        Assert.AreEqual("member", member.Data.Type);
        Assert.IsNotNull(member.Data.Id);
        Assert.IsNotNull(member.Links.Self);
    }

    [TestMethod]
    public async Task Member_WithAddress()
    {
        // Act
        var member = await PatreonAPIv2.Member(AppSettingsProvider.MemberId)
            .Include(PatreonTopLevelIncludes.V2.Members.Address)
            .IncludeAllFields<PatreonAddressAttributes>()
            .ExecuteAsync();

        // Assert
        Assert.AreEqual("member", member.Data.Type);
        Assert.IsNotNull(member.Data.Id);
        Assert.IsNotNull(member.Links.Self);
    }

    [TestMethod]
    public async Task Member_WithCampaign()
    {
        // Act
        var member = await PatreonAPIv2.Member(AppSettingsProvider.MemberId)
            .Include(PatreonTopLevelIncludes.V2.Members.Campaign)
            .IncludeAllFields<PatreonCampaignV2Attributes>()
            .ExecuteAsync();

        // Assert
        Assert.AreEqual("member", member.Data.Type);
        Assert.IsNotNull(member.Data.Id);
        Assert.IsNotNull(member.Links.Self);
    }

    [TestMethod]
    public async Task Member_WithCurrentlyEntitledTiers()
    {
        // Act
        var member = await PatreonAPIv2.Member(AppSettingsProvider.MemberId)
            .Include(PatreonTopLevelIncludes.V2.Members.CurrentlyEntitledTiers)
            .IncludeAllFields<PatreonTierAttributes>()
            .ExecuteAsync();

        // Assert
        Assert.AreEqual("member", member.Data.Type);
        Assert.IsNotNull(member.Data.Id);
        Assert.IsNotNull(member.Links.Self);
    }

    [TestMethod]
    public async Task Member_WithUser()
    {
        // Act
        var member = await PatreonAPIv2.Member(AppSettingsProvider.MemberId)
            .Include(PatreonTopLevelIncludes.V2.Members.User)
            .IncludeAllFields<PatreonUserV2Attributes>()
            .ExecuteAsync();

        // Assert
        Assert.AreEqual("member", member.Data.Type);
        Assert.IsNotNull(member.Data.Id);
        Assert.IsNotNull(member.Links.Self);
    }
}
