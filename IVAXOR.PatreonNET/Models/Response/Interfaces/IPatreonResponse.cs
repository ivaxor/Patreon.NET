using IVAXOR.PatreonNET.Models.Response.Relationships.Interfaces;

namespace IVAXOR.PatreonNET.Models.Response.Interfaces;

public interface IPatreonResponse<TAttributes, TRelationships>
    where TAttributes : IPatreonAttributes
    where TRelationships : IPatreonRelationships
{ }
