using IVAXOR.PatreonNET.IntegrationTests.Stubs.Services;
using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Models.Responses.Sets.V1;

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
        var response = await PatreonAPIv1.CurrentUser().ExecuteAsync();
        var user = new PatreonUserV1Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV1Attributes)], response.Data.Type);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(user.User);
    }

    [TestMethod]
    public async Task CurrentUser_IncludeField_AllOptional()
    {
        // Act
        var response = await PatreonAPIv1.CurrentUser()
            .IncludeField(_ => _.LikeCount)
            .IncludeField(_ => _.CommentCount)
            .ExecuteAsync();
        var user = new PatreonUserV1Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV1Attributes)], response.Data.Type);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(user.User);
    }

    [TestMethod]
    public async Task CurrentUser_Include_All()
    {
        // Act
        var response = await PatreonAPIv1.CurrentUser()
            .Include(PatreonTopLevelIncludes.V1.CurrentUser.Campaign)
            .Include(PatreonTopLevelIncludes.V1.CurrentUser.Pledges)
            .ExecuteAsync();
        var user = new PatreonUserV1Response(response);

        // Assert
        Assert.AreEqual(PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV1Attributes)], response.Data.Type);
        Assert.IsNotNull(response.Links.Self);

        Assert.IsNotNull(user.User);
    }
}
