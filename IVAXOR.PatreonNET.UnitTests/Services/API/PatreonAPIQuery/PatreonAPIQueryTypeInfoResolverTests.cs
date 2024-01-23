using IVAXOR.PatreonNET.Models;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;

namespace IVAXOR.PatreonNET.UnitTests.Services.API.PatreonAPIQuery;

[TestClass]
public class PatreonAPIQueryTypeInfoResolverTests
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
                Content = new StringContent("{\"data\":{\"attributes\":{},\"id\":\"00000000\",\"type\":\"user\"}}"),
            });
    }

    [TestMethod]
    public async Task ExecuteAsync_TypeInfoResolver_Default()
    {
        // Arrange
        JsonSerializerOptions.TypeInfoResolver = default;

        // Act
        var result = await PatreonAPIQuery.ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task ExecuteAsync_TypeInfoResolver_PatreonSourceGenerationContext()
    {
        // Arrange
        JsonSerializerOptions.TypeInfoResolver = PatreonSourceGenerationContext.Default;

        // Act
        var result = await PatreonAPIQuery.ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }
}
