using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;

namespace IVAXOR.PatreonNET.UnitTests.Services.API.PatreonAPIQuery;

[TestClass]
public class PatreonAPIQueryHttpStatusCodeTests
{
    protected PatreonAPIQuery<PatreonRawResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> PatreonAPIQuery => new("https://patreon.com", HttpClient, PatreonTokenManager);

    protected HttpClient HttpClient => new(HttpMessageHandlerMock.Object);
    protected Mock<HttpMessageHandler> HttpMessageHandlerMock { get; } = new();

    protected IPatreonTokenManager PatreonTokenManager => new Mock<IPatreonTokenManager>().Object;

    [TestInitialize]
    public void Initialize()
    {
        HttpMessageHandlerMock.Reset();
    }

    [DataTestMethod]
    [DataRow(HttpStatusCode.OK)]
    public async Task ExecuteAsync_SuccessStatusCode_ReturnsData(HttpStatusCode httpStatusCode)
    {
        // Arrange
        SetupHttpMessageHandlerMock(httpStatusCode, "{\"data\":{\"attributes\":{},\"id\":\"00000000\",\"type\":\"user\"}}");

        // Act
        var result = await PatreonAPIQuery.ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }

    [DataTestMethod]
    [DataRow(HttpStatusCode.BadRequest)]
    [DataRow(HttpStatusCode.Unauthorized)]
    [DataRow(HttpStatusCode.Forbidden)]
    [DataRow(HttpStatusCode.NotFound)]
    public async Task ExecuteAsync_UnsuccessStatusCode_ThrowsException(HttpStatusCode httpStatusCode)
    {
        // Arrange
        SetupHttpMessageHandlerMock(httpStatusCode, "Error occurred");

        // Act
        var exception = await Assert.ThrowsExceptionAsync<PatreonAPIException>(async () => await PatreonAPIQuery.ExecuteAsync());

        // Assert
        Assert.AreEqual((int)httpStatusCode, exception.StatusCode);
    }

    private void SetupHttpMessageHandlerMock(HttpStatusCode httpStatusCode, string content)
    {
        HttpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = httpStatusCode,
                Content = new StringContent(content),
            });
    }
}
