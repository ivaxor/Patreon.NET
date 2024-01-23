using IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;
using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;

namespace IVAXOR.PatreonNET.UnitTests.Models.Responses.Raw.Interfaces;

[TestClass]
public class PatreonAttributesRelationshipsTests
{
    [DataTestMethod]
    [DataRow(typeof(IPatreonAttributes), "Attributes")]
    [DataRow(typeof(IPatreonRelationships), "Relationships")]
    public void ClassName_ValidEnding(Type assignableType, string ending)
    {
        // Arrange
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(_ => _.GetTypes())
            .Where(_ => assignableType.IsAssignableFrom(_))
            .Where(_ => _ != assignableType)
            .ToHashSet();

        var invalidType = types.FirstOrDefault(_ => !_.Name.EndsWith(ending));

        // Assert
        Assert.IsNull(invalidType, "{0} class name do not ends with \"{1}\"", invalidType, ending);
    }
}
