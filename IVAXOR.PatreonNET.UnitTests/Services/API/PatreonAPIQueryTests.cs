using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;

namespace IVAXOR.PatreonNET.UnitTests.Services.API;

[TestClass]
public class PatreonAPIQueryTests
{
    protected PatreonAPIv1Query<PatreonResponseSingle<PatreonUserV1Attributes, PatreonUserV1Relationships>, PatreonUserV1Attributes, PatreonUserV1Relationships> PatreonAPIv1Query => new("https://patreon.com", HttpClient, PatreonTokenManager, JsonSerializerOptions);
    protected PatreonAPIv2Query<PatreonResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> PatreonAPIv2Query => new("https://patreon.com", HttpClient, PatreonTokenManager, JsonSerializerOptions);

    protected HttpClient HttpClient => new(HttpMessageHandlerMock.Object);
    protected Mock<HttpMessageHandler> HttpMessageHandlerMock { get; } = new();

    protected IPatreonTokenManager PatreonTokenManager => new Mock<IPatreonTokenManager>().Object;

    protected JsonSerializerOptions JsonSerializerOptions { get; } = new();

    [TestInitialize]
    public void Initialize()
    {
        HttpMessageHandlerMock.Reset();

        HttpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"data\":{\"attributes\":{},\"id\":\"97866959\",\"type\":\"user\",\"newProperty\":\"test\"}}"),
            });
    }

    [TestMethod]
    public async Task PatreonAPIv1Query_JsonUnmappedMemberHandling_Skip_SkipsNewProperty()
    {
        // Arrange
        JsonSerializerOptions.UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip;

        // Act
        var result = await PatreonAPIv1Query.ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task PatreonAPIv1Query_JsonUnmappedMemberHandling_Disallow_ThrowsException()
    {
        // Arrange
        JsonSerializerOptions.UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow;

        // Act
        var exception = await Assert.ThrowsExceptionAsync<JsonException>(async () => await PatreonAPIv1Query.ExecuteAsync());

        // Assert
        Assert.IsTrue(Regex.IsMatch(exception.Message, "The JSON property '\\w+' could not be mapped to any \\.NET member contained in type"));
    }

    [TestMethod]
    public async Task PatreonAPIv2Query_JsonUnmappedMemberHandling_Skip_SkipsNewProperty()
    {
        // Arrange
        JsonSerializerOptions.UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip;

        // Act
        var result = await PatreonAPIv2Query.ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task PatreonAPIv2Query_JsonUnmappedMemberHandling_Disallow_ThrowsException()
    {
        // Arrange
        JsonSerializerOptions.UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow;

        // Act
        var exception = await Assert.ThrowsExceptionAsync<JsonException>(async () => await PatreonAPIv2Query.ExecuteAsync());

        // Assert
        Assert.IsTrue(Regex.IsMatch(exception.Message, "The JSON property '\\w+' could not be mapped to any \\.NET member contained in type"));
    }
}
