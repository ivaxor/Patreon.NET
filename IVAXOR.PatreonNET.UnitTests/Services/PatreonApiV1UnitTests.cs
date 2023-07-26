namespace IVAXOR.PatreonNET.UnitTests.Services;

[TestClass]
public class PatreonApiV1UnitTests
{
    protected private readonly PatreonApiV1 PatreonAPI;

    public PatreonApiV1UnitTests()
    {
        PatreonAPI = new(null, null);
    }

    [TestMethod]
    public async Task GetCurrentUserCampaignsAsync_EmptyIncludes()
    {
        // Act
        // Assert
        await Assert.ThrowsExceptionAsync<NullReferenceException>(async () => await PatreonAPI.GetCurrentUserCampaignsAsync());
    }

    [TestMethod]
    [DataRow("rewards")]
    [DataRow("creator")]
    [DataRow("goals")]
    [DataRow("pledges")]
    public async Task GetCurrentUserCampaignsAsync_ValidIncludes(string include)
    {
        // Arrange
        var includes = new string[] { include };

        // Act
        // Assert
        await Assert.ThrowsExceptionAsync<NullReferenceException>(async () => await PatreonAPI.GetCurrentUserCampaignsAsync(includes));
    }

    [TestMethod]
    public async Task GetCurrentUserCampaignsAsync_AllValidIncludes()
    {
        // Arrange
        var includes = AvailableIncludes.V1CurrentUsercampaigns;

        // Act
        // Assert
        await Assert.ThrowsExceptionAsync<NullReferenceException>(async () => await PatreonAPI.GetCurrentUserCampaignsAsync(includes));
    }

    [TestMethod]
    public async Task GetCurrentUserCampaignsAsync_InvalidIncludes()
    {
        // Arrange
        var includes = new string[] { "invalid" };

        // Act
        // Assert
        await Assert.ThrowsExceptionAsync<InvalidIncludeException>(async () => await PatreonAPI.GetCurrentUserCampaignsAsync(includes));
    }
}
