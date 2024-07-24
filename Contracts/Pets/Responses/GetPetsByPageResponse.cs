using Contracts.Pets.Dtos;

namespace Contracts.Pets.Responses;

/// <summary>
/// Объект ответа на запрос страницы сущностей.
/// </summary>
public record GetPetsByPageResponse(IEnumerable<PetDto> Pets);
