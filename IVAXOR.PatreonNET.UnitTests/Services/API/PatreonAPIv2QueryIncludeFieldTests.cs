using IVAXOR.PatreonNET.Models.Resources.UsersV2;

namespace IVAXOR.PatreonNET.UnitTests.Services.API;

[TestClass]
public class PatreonAPIv2QueryIncludeFieldTests
{
    protected PatreonAPIv2Query<PatreonResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> PatreonAPIv2Query => new("https://patreon.com", HttpClient, PatreonTokenManager);

    protected HttpClient HttpClient => new(HttpMessageHandlerMock.Object);
    protected Mock<HttpMessageHandler> HttpMessageHandlerMock { get; } = new();

    protected IPatreonTokenManager PatreonTokenManager => new Mock<IPatreonTokenManager>().Object;

    [TestInitialize]
    public void Initialize()
    {
        HttpMessageHandlerMock.Reset();
    }

    [TestMethod]
    public async Task PatreonAPIv2Query_IncludeField_Expression_MemberExpression()
    {
        // Arrange
        Expression<Func<PatreonUserV2Attributes, object>> expression = _ => _.Email;
        var memberExpression = (MemberExpression)expression.Body;
        var memberInfo = memberExpression.Member;
        var memberJsonPropertyName = memberInfo.GetCustomAttribute<JsonPropertyNameAttribute>().Name;
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)];

        SetupIncludeFieldHttpMessageHandlerMock(resourceName, memberJsonPropertyName);

        // Act
        var result = await PatreonAPIv2Query
            .IncludeField(expression)
            .ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task PatreonAPIv2Query_IncludeField_Expression_UnaryExpression()
    {
        // Arrange
        Expression<Func<PatreonUserV2Attributes, object>> expression = _ => _.LikeCount;
        var unaryExpression = (UnaryExpression)expression.Body;
        var memberExpression = (MemberExpression)unaryExpression.Operand;
        var memberInfo = memberExpression.Member;
        var memberJsonPropertyName = memberInfo.GetCustomAttribute<JsonPropertyNameAttribute>().Name;
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)];

        SetupIncludeFieldHttpMessageHandlerMock(resourceName, memberJsonPropertyName);

        // Act
        var result = await PatreonAPIv2Query
            .IncludeField(expression)
            .ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task PatreonAPIv2Query_IncludeField_MemberInfo()
    {
        // Arrange
        var memberInfo = typeof(PatreonUserV2Attributes).GetMember(nameof(PatreonUserV2Attributes.Email)).Single();
        var memberJsonPropertyName = memberInfo.GetCustomAttribute<JsonPropertyNameAttribute>().Name;
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)];

        SetupIncludeFieldHttpMessageHandlerMock(resourceName, memberJsonPropertyName);

        // Act
        var result = await PatreonAPIv2Query
           .IncludeField(memberInfo)
           .ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task PatreonAPIv2Query_IncludeField()
    {
        // Arrange
        var memberInfo = typeof(PatreonUserV2Attributes).GetMember(nameof(PatreonUserV2Attributes.Email)).Single();
        var memberJsonPropertyName = memberInfo.GetCustomAttribute<JsonPropertyNameAttribute>().Name;
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)];

        SetupIncludeFieldHttpMessageHandlerMock(resourceName, memberJsonPropertyName);

        // Act
        var result = await PatreonAPIv2Query
           .IncludeField(resourceName, memberJsonPropertyName)
           .ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task PatreonAPIv2Query_IncludeAllFields()
    {
        // Arrange
        var memberJsonPropertyNames = typeof(PatreonUserV2Attributes).GetMembers()
            .Where(_ => _.GetCustomAttribute<JsonPropertyNameAttribute>() != null)
            .Select(_ => _.GetCustomAttribute<JsonPropertyNameAttribute>().Name)
            .ToArray();
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)];

        SetupIncludeFieldHttpMessageHandlerMock(resourceName, memberJsonPropertyNames);

        // Act
        var result = await PatreonAPIv2Query
           .IncludeAllFields()
           .ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
    }

    private void SetupIncludeFieldHttpMessageHandlerMock(string resourceName, params string[] memberJsonPropertyNames)
    {
        HttpMessageHandlerMock
           .Protected()
           .Setup<Task<HttpResponseMessage>>(
               "SendAsync",
               ItExpr.Is<HttpRequestMessage>(_ => _.RequestUri.AbsoluteUri.Contains($"fields%5B{resourceName}%5D") && memberJsonPropertyNames.All(__ => _.RequestUri.AbsoluteUri.Contains(__))),
               ItExpr.IsAny<CancellationToken>())
           .ReturnsAsync(new HttpResponseMessage()
           {
               StatusCode = HttpStatusCode.OK,
               Content = new StringContent("{\"data\":{\"attributes\":{},\"id\":\"97866959\",\"type\":\"user\"}}"),
           });
    }
}
