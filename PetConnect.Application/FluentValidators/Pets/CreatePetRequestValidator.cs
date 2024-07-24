using Contracts.Requests;
using FluentValidation;
using PetConnect.Domain.Common;
using PetConnect.Domain.Entities;
using PetConnect.Domain.ValueObjects;

namespace PetConnect.Application.FluentValidators.Pets;

/// <summary>
/// Валидация для класса <see cref="CreatePetRequest"/>.
/// </summary>
public class CreatePetRequestValidator : AbstractValidator<CreatePetRequest>
{
    public CreatePetRequestValidator()
    {
        RuleFor(x => x.Nickname)
            .NotEmpty()
            .WithError(Errors.General.ValueIsRequired(nameof(CreatePetRequest.Nickname)))
            .MaximumLength(Pet.MAX_NICKNAME_LENGTH)
            .WithError(Errors.General.InvalidLength(nameof(CreatePetRequest.Nickname)));

        RuleFor(x => x.Breed)
            .NotEmpty()
            .WithError(Errors.General.ValueIsRequired(nameof(CreatePetRequest.Breed)))
            .MaximumLength(Pet.MAX_BREED_LENGTH)
            .WithError(Errors.General.InvalidLength(nameof(CreatePetRequest.Breed)));

        RuleFor(x => x.Color)
            .NotEmpty()
            .WithError(Errors.General.ValueIsRequired(nameof(CreatePetRequest.Color)))
            .MaximumLength(Pet.MAX_COLOR_LENGTH)
            .WithError(Errors.General.InvalidLength(nameof(CreatePetRequest.Color)));

        RuleFor(x => x.PeopleAttitude)
            .NotEmpty()
            .WithError(Errors.General.ValueIsRequired(nameof(CreatePetRequest.PeopleAttitude)));

        RuleFor(x => x.AnimalAttitude)
            .NotEmpty()
            .WithError(Errors.General.ValueIsRequired(nameof(CreatePetRequest.AnimalAttitude)));

        RuleFor(x => x.Health)
            .NotEmpty()
            .WithError(Errors.General.ValueIsRequired(nameof(CreatePetRequest.Health)));

        // value-objects.
        RuleFor(x => x.Place).MustBeValueObject(Place.Create);
        RuleFor(x => x.ContactNumber).MustBeValueObject(PhoneNumber.Create);
        RuleFor(x => x.VolunteerPhoneNumber).MustBeValueObject(PhoneNumber.Create);
        RuleFor(x => x.Weight).MustBeValueObject(Weight.Create);
        RuleFor(x => new { x.City, x.Street, x.Building, x.Postcode }).MustBeValueObject(x => Address.Create(x.City, x.Street, x.Building, x.Postcode));
    }
}
