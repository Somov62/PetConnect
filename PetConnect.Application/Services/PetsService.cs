using Contracts.Pets.Dtos;
using Contracts.Pets.Requests;
using Contracts.Pets.Responses;
using CSharpFunctionalExtensions;
using PetConnect.Application.Abstractions;
using PetConnect.Application.Extensions;
using PetConnect.Domain.Common;
using PetConnect.Domain.Entities;
using PetConnect.Domain.ValueObjects;

namespace PetConnect.Application.Services;

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

        var idResult = await petsRepository.Add(pet.Value, cancellationToken);
        return idResult.IsSuccess ? idResult.Value : idResult.Error;
    }

    /// <summary>
    /// Возвращает всех животных.
    /// </summary>
    public async Task<GetPetsByPageResponse> GetByPage(GetPetsByPageRequest request, CancellationToken cancellationToken)
    {
        var pets = await petsRepository.GetByPage(request.Page, request.Size, cancellationToken);

        var petDtos = pets.Select(pet => pet.ToDto());

        return new(petDtos);
    }
}
