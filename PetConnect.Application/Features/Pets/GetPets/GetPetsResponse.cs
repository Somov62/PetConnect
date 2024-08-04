using PetConnect.Application.Dtos;

namespace PetConnect.Application.Features.Pets.GetPets;

/// <summary>
/// Ответ на запрос страницы сущностей.
/// </summary>
public record GetPetsResponse(IEnumerable<PetDto> Pets, int TotalCount);
