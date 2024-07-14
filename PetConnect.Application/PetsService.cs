using Contracts.Requests;
using CSharpFunctionalExtensions;
using PetConnect.Application.Abstractions;
using PetConnect.Domain.Common;
using PetConnect.Domain.Entities;
using PetConnect.Domain.ValueObjects;

namespace PetConnect.Application;

/// <summary>
/// Сервис для работы с сущностью животного <see cref="Pet"/>
/// </summary>
public class PetsService(IPetsRepository petsRepository)
{
    /// <summary>
    /// Добавляет информацию о животном в систему.
    /// </summary>
    public async Task<Result<Guid, Error>> CreatePet(CreatePetRequest request, CancellationToken cancellationToken)
    {
        // Инстанцируем value-objects.
        var address = Address.Create(request.City, request.Street, request.Building, request.Postcode);
        if (address.IsFailure)
            return address.Error;

        var place = Place.Create(request.Place);
        if (place.IsFailure)
            return place.Error;

        var weight = Weight.Create(request.Weight);
        if (weight.IsFailure)
            return weight.Error;

        var contactPhoneNumber = PhoneNumber.Create(request.ContactNumber);
        if (contactPhoneNumber.IsFailure)
            return contactPhoneNumber.Error;

        var volunteerPhoneNumber = PhoneNumber.Create(request.VolunteerPhoneNumber);
        if (volunteerPhoneNumber.IsFailure)
            return volunteerPhoneNumber.Error;

        var pet = Pet.Create(
                request.Nickname,
                request.Description,
                request.BirthDate,
                request.Breed,
                request.Color,
                place.Value,
                address.Value,
                request.Castration,
                request.PeopleAttitude,
                request.AnimalAttitude,
                request.Health,
                request.OnlyOneInFamily,
                request.Height,
                weight.Value,
                contactPhoneNumber.Value,
                volunteerPhoneNumber.Value,
                request.OnTreatment
            );

        if (pet.IsFailure) 
            return pet.Error;

        var idResult = await petsRepository.Add(pet.Value, cancellationToken);
        return idResult.IsSuccess ? idResult.Value : idResult.Error;
    }
}
