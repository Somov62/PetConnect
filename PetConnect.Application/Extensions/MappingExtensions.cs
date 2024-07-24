using Contracts.Pets.Dtos;
using PetConnect.Domain.Entities;

namespace PetConnect.Application.Extensions;

/// <summary>
/// 
/// </summary>
internal static class MappingExtensions
{
    /// <summary>
    /// 
    /// </summary>
    public static PetDto ToDto(this Pet pet)
    {
        return new(
            pet.Id,
            pet.Nickname,
            pet.Description,
            pet.Address.City,
            pet.Address.Street,
            pet.Address.Building,
            pet.Address.Postcode,
            pet.ContactPhoneNumber.Number);
    }
}
