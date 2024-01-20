using IVAXOR.PatreonNET.Models;
using IVAXOR.PatreonNET.Models.Responses.Raw;
using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;

namespace IVAXOR.PatreonNET.UnitTests.Models;

[TestClass]
public class PatreonSourceGenerationContextTests
{
    [DataTestMethod]
    [DataRow(typeof(IPatreonAttributes))]
    [DataRow(typeof(IPatreonRelationships))]
    public void TypeInfoResolver_AssignableInterfaces(Type type)
    {
        // Arrange
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(_ => _.GetTypes())
            .Where(_ => type.IsAssignableFrom(_))
            .Where(_ => _ != type)
            .ToHashSet();

        // Act
        var resolvers = types.ToDictionary(_ => _, _ => PatreonJsonConstants.DefaultJsonSerializerOptions.TypeInfoResolver.GetTypeInfo(_, PatreonJsonConstants.DefaultJsonSerializerOptions));

        // Assert
        var nullResolverType = resolvers
            .Where(_ => _.Value == null)
            .Select(_ => _.Key)
            .FirstOrDefault();

        Assert.IsNull(nullResolverType, "{0} type do not configured for source generation in {1}", nullResolverType, typeof(PatreonSourceGenerationContext));
    }

    [DataTestMethod]
    [DataRow(typeof(PatreonRawResponseSingle<,>))]
    [DataRow(typeof(PatreonRawResponseMulti<,>))]
    public void TypeInfoResolver_GenericResponses(Type type)
    {
        // Arrange
        var attributesEnding = "Attributes";
        var attributesTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(_ => _.GetTypes())
            .Where(_ => typeof(IPatreonAttributes).IsAssignableFrom(_))
            .Where(_ => _ != typeof(IPatreonAttributes))
            .ToDictionary(_ => _.Name, _ => _);
        var reducedAttributesTypes = attributesTypes.ToDictionary(_ => _.Key.Substring(0, _.Key.Length - attributesEnding.Length), _ => _.Value);

        var relationshipsEnding = "Relationships";
        var relationshipsTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(_ => _.GetTypes())
            .Where(_ => typeof(IPatreonRelationships).IsAssignableFrom(_))
            .Where(_ => _ != typeof(IPatreonRelationships))
            .ToDictionary(_ => _.Name, _ => _);
        var reducedRelationshipsTypes = relationshipsTypes.ToDictionary(_ => _.Key.Substring(0, _.Key.Length - relationshipsEnding.Length), _ => _.Value);

        var attributeRelationshipPairs = reducedAttributesTypes.Keys
            .Intersect(reducedRelationshipsTypes.Keys)
            .ToDictionary(_ => reducedAttributesTypes[_], _ => reducedRelationshipsTypes[_]);

        var types = attributeRelationshipPairs
            .Select(_ => type.MakeGenericType(_.Key, _.Value))
            .ToArray();

        // Act
        var resolvers = types.ToDictionary(_ => _, _ => PatreonJsonConstants.DefaultJsonSerializerOptions.TypeInfoResolver.GetTypeInfo(_, PatreonJsonConstants.DefaultJsonSerializerOptions));

        // Assert
        var nullResolverType = resolvers
            .Where(_ => _.Value == null)
            .Select(_ => _.Key)
            .FirstOrDefault();

        Assert.IsNull(nullResolverType, "{0} type do not configured for source generation in {1}", nullResolverType, typeof(PatreonSourceGenerationContext));

        Assert.IsTrue(attributesTypes.All(_ => _.Key.EndsWith(attributesEnding)));
        Assert.IsTrue(relationshipsTypes.All(_ => _.Key.EndsWith(relationshipsEnding)));
    }
}

