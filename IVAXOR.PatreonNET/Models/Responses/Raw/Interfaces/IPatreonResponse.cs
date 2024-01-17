using IVAXOR.PatreonNET.Models.Responses.Raw.Relationships.Interfaces;

namespace IVAXOR.PatreonNET.Models.Responses.Raw.Interfaces;

public interface IPatreonResponse<TAttributes, TRelationships>
    where TAttributes : IPatreonAttributes
    where TRelationships : IPatreonRelationships
{ }
