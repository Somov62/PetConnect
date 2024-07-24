namespace Contracts.Pets.Dtos;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Nickname"></param>
/// <param name="Description"></param>
/// <param name="City"></param>
/// <param name="Street"></param>
/// <param name="Building"></param>
/// <param name="Postcode"></param>
/// <param name="ContactPhoneNumber"></param>
public record PetDto(
    Guid Id,
    string Nickname,
    string Description,
    string City,
    string Street,
    string Building,
    string Postcode,
    string ContactPhoneNumber
    );