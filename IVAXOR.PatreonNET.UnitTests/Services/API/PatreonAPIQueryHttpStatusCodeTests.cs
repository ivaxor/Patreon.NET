using IVAXOR.PatreonNET.Models.Resources.UsersV1;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;

namespace IVAXOR.PatreonNET.UnitTests.Services.API;

[TestClass]
public class PatreonAPIQueryHttpStatusCodeTests
{
    protected PatreonAPIv1Query<PatreonRawResponseSingle<PatreonUserV1Attributes, PatreonUserV1Relationships>, PatreonUserV1Attributes, PatreonUserV1Relationships> PatreonAPIv1Query => new("https://patreon.com", HttpClient, PatreonTokenManager);
    protected PatreonAPIv2Query<PatreonRawResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> PatreonAPIv2Query => new("https://patreon.com", HttpClient, PatreonTokenManager);

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
    public async Task PatreonAPIv1Query_SuccessStatusCode_ReturnsData(HttpStatusCode httpStatusCode)
    {
        // Arrange
        SetupHttpMessageHandlerMock(httpStatusCode, "{\"data\":{\"attributes\":{},\"id\":\"00000000\",\"type\":\"user\"}}");

        // Act
        var result = await PatreonAPIv1Query.ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }

    [DataTestMethod]
    [DataRow(HttpStatusCode.BadRequest)]
    [DataRow(HttpStatusCode.Unauthorized)]
    [DataRow(HttpStatusCode.Forbidden)]
    [DataRow(HttpStatusCode.NotFound)]
    public async Task PatreonAPIv1Query_UnsuccessStatusCode_ThrowsException(HttpStatusCode httpStatusCode)
    {
        // Arrange
        SetupHttpMessageHandlerMock(httpStatusCode, "Error occurred");

        // Act
        var exception = await Assert.ThrowsExceptionAsync<PatreonAPIException>(async () => await PatreonAPIv1Query.ExecuteAsync());

        // Assert
        Assert.AreEqual((int)httpStatusCode, exception.StatusCode);
    }

    [DataTestMethod]
    [DataRow(HttpStatusCode.OK)]
    public async Task PatreonAPIv2Query_SuccessStatusCode_ReturnsData(HttpStatusCode httpStatusCode)
    {
        // Arrange
        SetupHttpMessageHandlerMock(httpStatusCode, "{\"data\":{\"attributes\":{},\"id\":\"00000000\",\"type\":\"user\"}}");

        // Act
        var result = await PatreonAPIv2Query.ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }

    [DataTestMethod]
    [DataRow(HttpStatusCode.BadRequest)]
    [DataRow(HttpStatusCode.Unauthorized)]
    [DataRow(HttpStatusCode.Forbidden)]
    [DataRow(HttpStatusCode.NotFound)]
    public async Task PatreonAPI21Query_UnsuccessStatusCode_ThrowsException(HttpStatusCode httpStatusCode)
    {
        // Arrange
        SetupHttpMessageHandlerMock(httpStatusCode, "Error occurred");

        // Act
        var exception = await Assert.ThrowsExceptionAsync<PatreonAPIException>(async () => await PatreonAPIv2Query.ExecuteAsync());

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
