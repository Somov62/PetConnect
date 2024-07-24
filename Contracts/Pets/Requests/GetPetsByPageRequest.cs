namespace Contracts.Pets.Requests;

/// <summary>
/// 
/// </summary>
public record GetPetsByPageRequest(int Size = 10, int Page = 1);
