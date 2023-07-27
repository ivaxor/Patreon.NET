namespace IVAXOR.PatreonNET.Models.Response.Interfaces
{
    public interface IPatreonResponse<TAttributes, TIRelationships>
        where TAttributes : IPatreonAttributes
        where TIRelationships : IPatreonRelationships
    { }
}
