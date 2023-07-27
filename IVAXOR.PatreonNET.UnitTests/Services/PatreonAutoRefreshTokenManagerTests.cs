using IVAXOR.PatreonNET.Models;
using IVAXOR.PatreonNET.Models.Configuration;
using IVAXOR.PatreonNET.Services.TokenManagers;

namespace IVAXOR.PatreonNET.UnitTests.Services;

[TestClass]
public class PatreonAutoRefreshTokenManagerTests
{
    [TestMethod]
    public async Task OnTimerElapsed()
    {
        // Arrange
        var httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        httpMessageHandlerMock
         .Protected()
         .Setup<Task<HttpResponseMessage>>(
            "SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>())
         .ReturnsAsync(new HttpResponseMessage()
         {
             StatusCode = HttpStatusCode.OK,
             Content = new StringContent("{\"access_token\":\"Test2\",\"refresh_token\":\"Test2\",\"expires_in\":500000,\"scope\":\"Test2\"}"),
         })
         .Verifiable();

        var httpClient = new HttpClient(httpMessageHandlerMock.Object);

        var patreonClient = new PatreonClient()
        {
            ClientId = "TestClientId",
            ClientSecret = "TestClientSecret"
        };
        var patreonClientTokens = new PatreonClientTokens()
        {
            AccessToken = "Test1",
            RefreshToken = "Test1",
            ExpiresIn = Convert.ToInt32(TimeSpan.FromMinutes(1).TotalMilliseconds) + 1
        };

        // Act
        var patreonAutoRefreshTokenManager = new PatreonAutoRefreshTokenManager(httpClient, patreonClient, patreonClientTokens);
        await Task.Delay(200);

        // Assert
        Assert.AreNotEqual(patreonClientTokens.AccessToken, patreonAutoRefreshTokenManager.AccessToken);

        httpMessageHandlerMock
            .Protected()
            .Verify<Task<HttpResponseMessage>>(
                "SendAsync",
                Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>());
    }
}
