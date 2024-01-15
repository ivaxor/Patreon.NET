using IVAXOR.PatreonNET.Models.Resources.CampaignsV1;
using IVAXOR.PatreonNET.Models.Resources.PledgeV1;
using IVAXOR.PatreonNET.Models.Resources.PostsV1;
using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Services.TokenManagers.Interfaces;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V1;

[TestClass]
public class PatreonAPIv1IntegrationTests
{
    protected HttpClient HttpClient { get; }
    protected IPatreonTokenManager TokenManager { get; }
    protected PatreonAPIv1 PatreonAPIv1 { get; }

    public PatreonAPIv1IntegrationTests()
    {
        HttpClient = new HttpClient();
        TokenManager = new PatreonStubTokenManager();

        PatreonAPIv1 = new(HttpClient, TokenManager);
    }

    [TestMethod]
    public async Task CurrentUser()
    {
        // Act
        var currentUser = await PatreonAPIv1.CurrentUser().ExecuteAsync();

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV1Attributes)], currentUser.Data.Type);
        Assert.IsNotNull(currentUser.Data.Attributes.Created);
        Assert.IsNotNull(currentUser.Data.Attributes.Email);
        Assert.IsNotNull(currentUser.Data.Attributes.Url);
        Assert.IsNotNull(currentUser.Links.Self);
    }

    [TestMethod]
    public async Task CurrentUser_Include()
    {
        // Act
        var currentUser = await PatreonAPIv1.CurrentUser()
            .Include(PatreonTopLevelIncludes.V1.CurrentUser.Campaign)
            .Include(PatreonTopLevelIncludes.V1.CurrentUser.Pledges)
            .ExecuteAsync();

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV1Attributes)], currentUser.Data.Type);
        Assert.IsNotNull(currentUser.Data.Attributes.Created);
        Assert.IsNotNull(currentUser.Data.Attributes.Email);
        Assert.IsNotNull(currentUser.Data.Attributes.Url);
        Assert.IsNotNull(currentUser.Links.Self);
    }

    [TestMethod]
    public async Task CurrentUserCampaigns()
    {
        // Act
        var currentUserCampaigns = await PatreonAPIv1.CurrentUserCampaigns().ExecuteAsync();

        // Assert
        Assert.IsTrue(currentUserCampaigns.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV1Attributes)]));
    }

    [TestMethod]
    public async Task CurrentUserCampaigns_Include()
    {
        // Act
        var currentUserCampaigns = await PatreonAPIv1.CurrentUserCampaigns()
            .Include(PatreonTopLevelIncludes.V1.CurrentUserCampaigns.Creator)
            .Include(PatreonTopLevelIncludes.V1.CurrentUserCampaigns.Goals)
            .Include(PatreonTopLevelIncludes.V1.CurrentUserCampaigns.Rewards)
            .Include(PatreonTopLevelIncludes.V1.CurrentUserCampaigns.Pledges)
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(currentUserCampaigns.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV1Attributes)]));
    }

    [TestMethod]
    public async Task CampaignPledges()
    {
        // Act
        var campaignPledges = await PatreonAPIv1.CampaignPledges(AppSettingsProvider.CampaignId).ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPledges.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPledgeV1Attributes)]));
    }

    [TestMethod]
    public async Task CampaignPledges_Include()
    {
        // Act
        var campaignPledges = await PatreonAPIv1.CampaignPledges(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V1.CampaignPledges.Address)
            .Include(PatreonTopLevelIncludes.V1.CampaignPledges.Creator)
            .Include(PatreonTopLevelIncludes.V1.CampaignPledges.Patron)
            .Include(PatreonTopLevelIncludes.V1.CampaignPledges.Reward)
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPledges.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPledgeV1Attributes)]));
    }

    [TestMethod]
    public async Task CampaignPledges_ManualUrl()
    {
        // Arrange
        var url = $"https://patreon.com/api/oauth2/api/campaigns/{AppSettingsProvider.CampaignId}/pledges?page%5Bcount%5D=10&sort=created&page%5Bcursor%5D=2017-08-21T20%3A16%3A49.258893%2B00%3A00";
        var query = new PatreonAPIv1Query<PatreonResponseMulti<PatreonPledgeV1Attributes, PatreonPledgeV1Relationships>, PatreonPledgeV1Attributes, PatreonPledgeV1Relationships>(url, HttpClient, TokenManager);

        // Act
        var campaignPledges = await query.ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPledges.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPledgeV1Attributes)]));
    }

    [TestMethod]
    public async Task CampaignPosts()
    {
        // Act
        var campaignPosts = await PatreonAPIv1.CampaignPosts(AppSettingsProvider.CampaignId).ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPosts.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPostV1Attributes)]));
    }

    [TestMethod]
    public async Task CampaignPosts_Include()
    {
        // Act
        var campaignPosts = await PatreonAPIv1.CampaignPosts(AppSettingsProvider.CampaignId)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Attachments)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Campaign)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.ContentLocks)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Comments)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.Likes)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.User)
            .Include(PatreonTopLevelIncludes.V1.CampaignPosts.UserDefinedTags)
            .ExecuteAsync();

        // Assert
        Assert.IsTrue(campaignPosts.Data.All(_ => _.Type == PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonPostV1Attributes)]));
    }
}
