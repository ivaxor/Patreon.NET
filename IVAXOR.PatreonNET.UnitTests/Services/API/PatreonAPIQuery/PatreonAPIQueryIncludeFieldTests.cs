using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;

namespace IVAXOR.PatreonNET.UnitTests.Services.API.PatreonAPIQuery;

[TestClass]
public class PatreonAPIQueryIncludeFieldTests
{
    protected PatreonAPIQuery<PatreonRawResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> PatreonAPIQuery => new("https://patreon.com", null, null);

    [TestMethod]
    public async Task IncludeField_Expression_MemberExpression()
    {
        // Arrange
        Expression<Func<PatreonUserV2Attributes, object>> expression = _ => _.Email;
        var memberExpression = (MemberExpression)expression.Body;
        var memberInfo = memberExpression.Member;
        var memberJsonPropertyName = memberInfo.GetCustomAttribute<JsonPropertyNameAttribute>().Name;
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)];

        // Act
        var query = PatreonAPIQuery.IncludeField(expression);

        // Assert
        Assert.AreEqual(resourceName, query.IncludedFieldsByResource.Single().Key);
        Assert.AreEqual(memberJsonPropertyName, query.IncludedFieldsByResource.Single().Value.Single());
    }

    [TestMethod]
    public async Task IncludeField_Expression_UnaryExpression()
    {
        // Arrange
        Expression<Func<PatreonUserV2Attributes, object>> expression = _ => _.LikeCount;
        var unaryExpression = (UnaryExpression)expression.Body;
        var memberExpression = (MemberExpression)unaryExpression.Operand;
        var memberInfo = memberExpression.Member;
        var memberJsonPropertyName = memberInfo.GetCustomAttribute<JsonPropertyNameAttribute>().Name;
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)];

        // Act
        var query = PatreonAPIQuery.IncludeField(expression);

        // Assert
        Assert.AreEqual(resourceName, query.IncludedFieldsByResource.Single().Key);
        Assert.AreEqual(memberJsonPropertyName, query.IncludedFieldsByResource.Single().Value.Single());
    }

    [TestMethod]
    public async Task IncludeField_MemberInfo()
    {
        // Arrange
        var memberInfo = typeof(PatreonUserV2Attributes).GetMember(nameof(PatreonUserV2Attributes.Email)).Single();
        var memberJsonPropertyName = memberInfo.GetCustomAttribute<JsonPropertyNameAttribute>().Name;
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)];

        // Act
        var query = PatreonAPIQuery.IncludeField(memberInfo);

        // Assert
        Assert.AreEqual(resourceName, query.IncludedFieldsByResource.Single().Key);
        Assert.AreEqual(memberJsonPropertyName, query.IncludedFieldsByResource.Single().Value.Single());
    }

    [TestMethod]
    public async Task IncludeField()
    {
        // Arrange
        var memberInfo = typeof(PatreonUserV2Attributes).GetMember(nameof(PatreonUserV2Attributes.Email)).Single();
        var memberJsonPropertyName = memberInfo.GetCustomAttribute<JsonPropertyNameAttribute>().Name;
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)];

        // Act
        var query = PatreonAPIQuery.IncludeField(resourceName, memberJsonPropertyName);

        // Assert
        Assert.AreEqual(resourceName, query.IncludedFieldsByResource.Single().Key);
        Assert.AreEqual(memberJsonPropertyName, query.IncludedFieldsByResource.Single().Value.Single());
    }

    [TestMethod]
    public async Task IncludeAllFields()
    {
        // Arrange
        var memberJsonPropertyNames = typeof(PatreonUserV2Attributes).GetMembers()
            .Where(_ => _.GetCustomAttribute<JsonPropertyNameAttribute>() != null)
            .Select(_ => _.GetCustomAttribute<JsonPropertyNameAttribute>().Name)
            .ToArray();
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)];

        // Act
        var query = PatreonAPIQuery.IncludeAllFields();

        // Assert
        Assert.AreEqual(resourceName, query.IncludedFieldsByResource.Single().Key);
        CollectionAssert.AreEqual(memberJsonPropertyNames, query.IncludedFieldsByResource.Single().Value.ToArray());
    }
}
