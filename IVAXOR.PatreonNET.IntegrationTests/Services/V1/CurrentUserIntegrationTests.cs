using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.UsersV1;

namespace IVAXOR.PatreonNET.IntegrationTests.Services.V1;

[TestClass]
public class CurrentUserIntegrationTests
{
    protected PatreonAPIv1 PatreonAPIv1 { get; }

    public CurrentUserIntegrationTests()
    {
        var httpClient = new HttpClient();
        var tokenManager = new PatreonAppSettingsTokenManager();

        PatreonAPIv1 = new(httpClient, tokenManager);
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
    public async Task CurrentUser_IncludeField()
    {
        // Act
        var currentUser = await PatreonAPIv1.CurrentUser().ExecuteAsync();

        // TODO: Add optional field functionality
        // When requesting some of these resources in our API they will have sensible defaults for what attributes are included. To request optional attributes, e.g. like_count and comment_count, specify the fields parameter in the URL like https://www.patreon.com/api/oauth2/api/current_user?fields[user]=like_count,comment_count. For more information, see the JSON:API docs.

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV1Attributes)], currentUser.Data.Type);
        Assert.IsNotNull(currentUser.Data.Attributes.Created);
        Assert.IsNotNull(currentUser.Data.Attributes.Email);
        Assert.IsNotNull(currentUser.Data.Attributes.Url);
        Assert.IsNotNull(currentUser.Links.Self);
    }

    [TestMethod]
    public async Task CurrentUser_WithCampaign()
    {
        // Act
        var currentUser = await PatreonAPIv1.CurrentUser()
            .Include(PatreonTopLevelIncludes.V1.CurrentUser.Campaign)
            .ExecuteAsync();

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV1Attributes)], currentUser.Data.Type);
        Assert.IsNotNull(currentUser.Data.Attributes.Created);
        Assert.IsNotNull(currentUser.Data.Attributes.Email);
        Assert.IsNotNull(currentUser.Data.Attributes.Url);
        Assert.IsNotNull(currentUser.Links.Self);
    }

    [TestMethod]
    public async Task CurrentUser_WithPledges()
    {
        // Act
        var currentUser = await PatreonAPIv1.CurrentUser()
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
    public async Task CurrentUser_WithAll()
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
}
