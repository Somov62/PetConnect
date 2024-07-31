using PetConnect.Application.Dtos;

namespace PetConnect.Application.Features.Pets.GetPets;

/// <summary>
/// Объект ответа на запрос страницы сущностей.
/// </summary>
public record GetPetsResponse(IEnumerable<PetDto> Pets, int TotalCount);
