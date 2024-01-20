using IVAXOR.PatreonNET.Models;
using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Models.Responses.Raw;

namespace IVAXOR.PatreonNET.UnitTests.Services.API;

[TestClass]
public class PatreonAPIQueryTypeInfoResolverTests
{
    protected PatreonAPIv1Query<PatreonRawResponseSingle<PatreonUserV1Attributes, PatreonUserV1Relationships>, PatreonUserV1Attributes, PatreonUserV1Relationships> PatreonAPIv1Query => new("https://patreon.com", HttpClient, PatreonTokenManager, JsonSerializerOptions);

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
                Content = new StringContent("{\"data\":{\"attributes\":{},\"id\":\"00000000\",\"type\":\"user\",\"newUnknownProperty\":\"test\"}}"),
            });
    }

    [TestMethod]
    public async Task TypeInfoResolver_Default()
    {
        // Arrange
        JsonSerializerOptions.TypeInfoResolver = default;

        // Act
        var result = await PatreonAPIv1Query.ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task TypeInfoResolver_PatreonSourceGenerationContext()
    {
        // Arrange
        JsonSerializerOptions.TypeInfoResolver = PatreonSourceGenerationContext.Default;

        // Act
        var result = await PatreonAPIv1Query.ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }
}
