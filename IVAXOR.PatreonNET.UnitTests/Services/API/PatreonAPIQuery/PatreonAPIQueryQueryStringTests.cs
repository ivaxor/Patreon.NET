using IVAXOR.PatreonNET.Models.Resources.CampaignsV2;
using IVAXOR.PatreonNET.Models.Resources.UsersV2;
using IVAXOR.PatreonNET.Models.Responses.Raw;

namespace IVAXOR.PatreonNET.UnitTests.Services.API.PatreonAPIQuery;

[TestClass]
public class PatreonAPIQueryQueryStringTests
{
    protected PatreonAPIQuery<PatreonRawResponseSingle<PatreonUserV2Attributes, PatreonUserV2Relationships>, PatreonUserV2Attributes, PatreonUserV2Relationships> PatreonAPIQuery => new("https://patreon.com", null, null);

    [TestMethod]
    public void BuildQuery_Include_Single()
    {
        // Arrange
        var topLevelInclude = PatreonTopLevelIncludes.V2.Identity.Campaign;

        var query = PatreonAPIQuery.Include(topLevelInclude);

        // Act
        var queryString = query.BuildQuery();

        // Assert
        Assert.IsTrue(queryString.Contains($"include={topLevelInclude}"));
    }

    [TestMethod]
    public void BuildQuery_Include_Multiple()
    {
        // Arrange
        var topLevelIncludes = new HashSet<string>()
        {
            PatreonTopLevelIncludes.V2.Identity.Campaign,
            PatreonTopLevelIncludes.V2.Identity.Memberships,
        };

        var query = PatreonAPIQuery;
        foreach (var topLevelInclude in topLevelIncludes) query.Include(topLevelInclude);

        // Act
        var queryString = query.BuildQuery();

        // Assert
        var joinedIncludes = string.Join(',', topLevelIncludes);
        Assert.IsTrue(queryString.Contains($"include={joinedIncludes}"));
    }

    [TestMethod]
    public void BuildQuery_IncludeField_SingleField()
    {
        // Arrange
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)];
        var fieldName = typeof(PatreonUserV2Attributes).GetMember(nameof(PatreonUserV2Attributes.Email)).Single().GetCustomAttribute<JsonPropertyNameAttribute>().Name;

        var query = PatreonAPIQuery.IncludeField(resourceName, fieldName);

        // Act
        var queryString = query.BuildQuery();

        // Assert
        var expectedQuerySubString = $"fields[{resourceName}]={fieldName}";
        var expectedEncodedQuerySubString = expectedQuerySubString.Replace("[", "%5B").Replace("]", "%5D");
        Assert.IsTrue(queryString.Contains(expectedEncodedQuerySubString));
    }

    [TestMethod]
    public void BuildQuery_IncludeField_MultipleFields()
    {
        // Arrange
        var resourceName = PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)];
        var fieldNames = typeof(PatreonUserV2Attributes).GetMembers()
            .Where(_ => _.GetCustomAttribute<JsonPropertyNameAttribute>() != null)
            .Select(_ => _.GetCustomAttribute<JsonPropertyNameAttribute>().Name)
            .ToArray();

        var query = PatreonAPIQuery;
        foreach (var fieldName in fieldNames) query.IncludeField(resourceName, fieldName);

        // Act
        var queryString = query.BuildQuery();

        // Assert
        var joinedFields = string.Join(',', fieldNames);
        var expectedQuerySubString = $"fields[{resourceName}]={joinedFields}";
        var expectedEncodedQuerySubString = expectedQuerySubString.Replace("[", "%5B").Replace("]", "%5D");
        Assert.IsTrue(queryString.Contains(expectedEncodedQuerySubString));
    }

    [TestMethod]
    public void BuildQuery_IncludeField_MultipleResources()
    {
        // Arrange
        var resourceNames = new HashSet<string>()
        {
            PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonUserV2Attributes)],
            PatreonResponseDataTypes.TypeByPatreonAttributes[typeof(PatreonCampaignV2Attributes)]
        };
        var fieldName = typeof(PatreonUserV2Attributes).GetMember(nameof(PatreonUserV2Attributes.Url)).Single().GetCustomAttribute<JsonPropertyNameAttribute>().Name;

        var query = PatreonAPIQuery;
        foreach (var resourceName in resourceNames) query.IncludeField(resourceName, fieldName);

        // Act
        var queryString = query.BuildQuery();

        // Assert
        var expectedEncodedQuerySubStrings = resourceNames
            .Select(_ => $"fields[{_}]={fieldName}")
            .Select(_ => _.Replace("[", "%5B").Replace("]", "%5D"))
            .ToArray();

        Assert.IsTrue(expectedEncodedQuerySubStrings.All(_ => queryString.Contains(_)));
    }

    [TestMethod]
    public void BuildQuery_SetPageSize()
    {
        // Arrange
        var pageSize = 10;
        var query = PatreonAPIQuery.SetPageSize(pageSize);

        // Act
        var queryString = query.BuildQuery();

        // Assert
        var expectedQuerySubString = $"page[count]={pageSize}";
        var expectedEncodedQuerySubString = expectedQuerySubString.Replace("[", "%5B").Replace("]", "%5D");
        Assert.IsTrue(queryString.Contains(expectedEncodedQuerySubString));
    }

    [TestMethod]
    public void BuildQuery_SortBy_Desc()
    {
        // Arrange
        var fieldName = typeof(PatreonUserV2Attributes).GetMember(nameof(PatreonUserV2Attributes.Created)).Single().GetCustomAttribute<JsonPropertyNameAttribute>().Name;
        var query = PatreonAPIQuery.SortBy(fieldName, true);

        // Act
        var queryString = query.BuildQuery();

        // Assert
        var expectedQuerySubString = $"sort=-{fieldName}";
        Assert.IsTrue(queryString.Contains(expectedQuerySubString));
    }

    [TestMethod]
    public void BuildQuery_SortBy_Asc()
    {
        // Arrange
        var fieldName = typeof(PatreonUserV2Attributes).GetMember(nameof(PatreonUserV2Attributes.Created)).Single().GetCustomAttribute<JsonPropertyNameAttribute>().Name;
        var query = PatreonAPIQuery.SortBy(fieldName, false);

        // Act
        var queryString = query.BuildQuery();

        // Assert
        var expectedQuerySubString = $"sort={fieldName}";
        Assert.IsTrue(queryString.Contains(expectedQuerySubString));
    }

    [TestMethod]
    public void BuildQuery_SetCursor_WithoutSortBy()
    {
        // Arrange
        var cursor = DateTime.UtcNow;
        var query = PatreonAPIQuery.SetCursor(cursor);

        // Act
        var queryString = query.BuildQuery();

        // Assert
        Assert.AreEqual(string.Empty, queryString);
    }

    [TestMethod]
    public void BuildQuery_SetCursor_SortBy()
    {
        // Arrange
        var cursor = DateTime.UtcNow;

        var query = PatreonAPIQuery
            .SetCursor(cursor)
            .SortBy(_ => _.Created, false);

        // Act
        var queryString = query.BuildQuery();

        // Assert
        var formattedCursor = cursor.ToString("yyyy-MM-dd");
        var expectedQuerySubString = $"page[cursor]={formattedCursor}";
        var expectedEncodedQuerySubString = expectedQuerySubString.Replace("[", "%5B").Replace("]", "%5D");
        Assert.IsTrue(queryString.Contains(expectedEncodedQuerySubString));
    }
}
