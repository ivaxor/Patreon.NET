using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;

namespace IVAXOR.PatreonNET.UnitTests.Services.API;

[TestClass]
public class PatreonAPIQueryUnmappedMemberHandlingTests
{
    protected PatreonAPIQuery<PatreonRawResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> PatreonAPIQuery => new("https://patreon.com", HttpClient, PatreonTokenManager, JsonSerializerOptions);

    protected HttpClient HttpClient => new(HttpMessageHandlerMock.Object);
    protected Mock<HttpMessageHandler> HttpMessageHandlerMock { get; } = new();

    protected IPatreonTokenManager PatreonTokenManager => new Mock<IPatreonTokenManager>().Object;

    protected JsonSerializerOptions JsonSerializerOptions { get; set; } = new();

    [TestInitialize]
    public void Initialize()
    {
        JsonSerializerOptions = new();

        HttpMessageHandlerMock.Reset();
        HttpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"data\":{\"attributes\":{},\"id\":\"00000000\",\"type\":\"user\",\"newUnknownProperty\":\"test\"}}"),
            });
    }

    [TestMethod]
    public async Task ExecuteAsync_UnmappedMemberHandling_Skip_SkipsNewProperty()
    {
        // Arrange
        JsonSerializerOptions.UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip;

        // Act
        var result = await PatreonAPIQuery.ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task ExecuteAsync_UnmappedMemberHandling_Disallow_ThrowsException()
    {
        // Arrange
        JsonSerializerOptions.UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow;

        // Act
        var exception = await Assert.ThrowsExceptionAsync<JsonException>(async () => await PatreonAPIQuery.ExecuteAsync());

        // Assert
        Assert.IsTrue(Regex.IsMatch(exception.Message, "The JSON property '\\w+' could not be mapped to any \\.NET member contained in type"));
    }
}
