using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;
using PetConnect.Domain.Entities;
using PetConnect.Domain.ValueObjects;

namespace PetConnect.Application.Features.Volunteers.CreatePet;

/// <summary>
/// Сервис для работы с сущностью животного <see cref="Pet"/>
/// </summary>
public class CreatePetService(IVolunteerRepository repository)
{
    /// <summary>
    /// Добавляет информацию о животном в систему.
    /// </summary>
    public async Task<Result<Guid, Error>> Execute(CreatePetRequest request, CancellationToken cancellationToken)
    {
         var volunteerResult = await repository.GetById(request.VolunteerId, cancellationToken);

        if (volunteerResult.IsFailure)
            return volunteerResult.Error;

        var volunteer = volunteerResult.Value;


        // Инстанцируем value-objects.
        var address = Address.Create(request.City, request.Street, request.Building, request.Postcode).Value;

        var place = Place.Create(request.Place).Value;

        var weight = Weight.Create(request.Weight).Value;

        var contactPhoneNumber = PhoneNumber.Create(request.ContactNumber).Value;

        var volunteerPhoneNumber = PhoneNumber.Create(request.VolunteerPhoneNumber).Value;

        var pet = Pet.Create(
                request.Nickname,
                request.Description,
                request.BirthDate,
                request.Breed,
                request.Color,
                place,
                address,
                request.Castration,
                request.PeopleAttitude,
                request.AnimalAttitude,
                request.Health,
                request.OnlyOneInFamily,
                request.Height,
                weight,
                contactPhoneNumber,
                volunteerPhoneNumber,
                request.OnTreatment
            );

        if (pet.IsFailure)
            return pet.Error;

        volunteer.PublishPet(pet.Value);
        return await repository.Save(volunteer, cancellationToken);
    }
}
