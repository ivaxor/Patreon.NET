using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;

namespace IVAXOR.PatreonNET.UnitTests.Constants;

[TestClass]
public class PatreonResponseDataTypesTests
{
    [TestMethod]
    public void PatreonAttributesByTypes_Unique()
    {
        // Arrange
        var attributes = PatreonResponseDataTypes.PatreonAttributesByTypes.Values
            .SelectMany(_ => _)
            .ToArray();

        var uniqueAttributes = attributes
            .Distinct()
            .ToArray();

        // Assert
        Assert.AreEqual(uniqueAttributes.Length, attributes.Length);
    }

    [TestMethod]
    public void PatreonAttributesByTypes_ImplementsInterface()
    {
        // Arrange
        var interfaceType = typeof(IPatreonAttributes);

        var invalidAttributes = PatreonResponseDataTypes.PatreonAttributesByTypes.Values
            .SelectMany(_ => _)
            .Where(_ => !interfaceType.IsAssignableFrom(_))
            .ToArray();

        // Assert
        Assert.AreEqual(0, invalidAttributes.Length, "{0} do not implements {1} interface", invalidAttributes.FirstOrDefault()?.Name, interfaceType);
    }

    [TestMethod]
    public void PatreonRelationshipsByTypes_Unique()
    {
        // Arrange
        var relationships = PatreonResponseDataTypes.PatreonRelationshipsByTypes.Values
            .SelectMany(_ => _)
            .ToArray();

        var uniqueRelationships = relationships
            .Distinct()
            .ToArray();

        // Assert
        Assert.AreEqual(uniqueRelationships.Length, relationships.Length);
    }

    [TestMethod]
    public void PatreonRelationshipsByTypes_ImplementsInterface()
    {
        // Arrange
        var interfaceType = typeof(IPatreonRelationships);

        var invalidRelationships = PatreonResponseDataTypes.PatreonRelationshipsByTypes.Values
            .SelectMany(_ => _)
            .Where(_ => !interfaceType.IsAssignableFrom(_))
            .ToArray();

        // Assert
        Assert.AreEqual(0, invalidRelationships.Length, "{0} do not implements {1} interface", invalidRelationships.FirstOrDefault()?.Name, interfaceType);
    }
}
