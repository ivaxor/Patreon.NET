using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.Addresses;
using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.Members;
using IVAXOR.PatreonNET.Models.Resources.Tiers;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Sets.V2;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V2;

[TestClass]
public class MemberIntegrationTests
{
    protected PatreonAPIv2 PatreonAPIv2 { get; }

    public MemberIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonAppSettingsTokenManager();

        PatreonAPIv2 = new(httpClient, tokenManager);
    }

    [TestMethod]
    public async Task Member()
    {
        // Act
        var response = await PatreonAPIv2.Member(AppSettingsProvider.MemberId).ExecuteAsync();
        var membership = new PatreonMembershipV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonMemberAttributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.MemberId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(membership.Member);
    }

    [TestMethod]
    public async Task Member_IncludeField_All()
    {
        // Act
        var response = await PatreonAPIv2.Member(AppSettingsProvider.MemberId)
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
        var membership = new PatreonMembershipV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonMemberAttributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.MemberId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(membership.Member);
    }

    [TestMethod]
    public async Task Member_IncludeAllFields()
    {
        // Act
        var response = await PatreonAPIv2.Member(AppSettingsProvider.MemberId)
            .IncludeAllFields()
            .ExecuteAsync();
        var membership = new PatreonMembershipV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonMemberAttributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.MemberId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(membership.Member);
    }

    [TestMethod]
    public async Task Member_Include_IncludeAllFields_Address()
    {
        // Act
        var response = await PatreonAPIv2.Member(AppSettingsProvider.MemberId)
            .Include(PatreonTopLevelIncludes.V2.Members.Address)
            .IncludeAllFields<PatreonAddressAttributes>()
            .ExecuteAsync();
        var membership = new PatreonMembershipV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonMemberAttributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.MemberId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(membership.Member);
    }

    [TestMethod]
    public async Task Member_Include_IncludeAllFields_Campaign()
    {
        // Act
        var response = await PatreonAPIv2.Member(AppSettingsProvider.MemberId)
            .Include(PatreonTopLevelIncludes.V2.Members.Campaign)
            .IncludeAllFields<PatreonCampaignV2Attributes>()
            .ExecuteAsync();
        var membership = new PatreonMembershipV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonMemberAttributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.MemberId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(membership.Member);
        Assert.IsNotNull(membership.Campaign);
    }

    [TestMethod]
    public async Task Member_Include_IncludeAllFields_CurrentlyEntitledTiers()
    {
        // Act
        var response = await PatreonAPIv2.Member(AppSettingsProvider.MemberId)
            .Include(PatreonTopLevelIncludes.V2.Members.CurrentlyEntitledTiers)
            .IncludeAllFields<PatreonTierAttributes>()
            .ExecuteAsync();
        var membership = new PatreonMembershipV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonMemberAttributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.MemberId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(membership.Member);
        Assert.IsNotNull(membership.CurrentlyEntitledTiers);
    }

    [TestMethod]
    public async Task Member_Include_IncludeAllFields_User()
    {
        // Act
        var response = await PatreonAPIv2.Member(AppSettingsProvider.MemberId)
            .Include(PatreonTopLevelIncludes.V2.Members.User)
            .IncludeAllFields<PatreonUserV2Attributes>()
            .ExecuteAsync();
        var membership = new PatreonMembershipV2Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonMemberAttributes)], response.Data.Type);
        Assert.AreEqual(AppSettingsProvider.MemberId, response.Data.Id);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(membership.Member);
        Assert.IsNotNull(membership.User);
    }
}
