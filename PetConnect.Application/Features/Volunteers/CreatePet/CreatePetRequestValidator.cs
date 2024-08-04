using FluentValidation;
using PetConnect.Application.FluentValidators;
using PetConnect.Domain.Common;
using PetConnect.Domain.Entities;
using PetConnect.Domain.ValueObjects;

namespace PetConnect.Application.Features.Volunteers.CreatePet;

/// <summary>
/// Валидация для класса <see cref="CreatePetRequest"/>.
/// </summary>
public class CreatePetRequestValidator : AbstractValidator<CreatePetRequest>
{
    public CreatePetRequestValidator()
    {
        RuleFor(x => x.Nickname)
           .NotEmptyWithError()
           .MaximumLengthWithError(Pet.MAX_NICKNAME_LENGTH);

        RuleFor(x => x.Description)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.LONG_TITLE_LENGTH);

        RuleFor(x => x.BirthDate)
            .LessThanWithError(DateTimeOffset.UtcNow);

        RuleFor(x => x.Breed)
            .NotEmptyWithError()
            .MaximumLengthWithError(Pet.MAX_BREED_LENGTH);

        RuleFor(x => x.Color)
            .NotEmptyWithError()
            .MaximumLengthWithError(Pet.MAX_COLOR_LENGTH);

        RuleFor(x => x.Place)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.SHORT_TITLE_LENGTH);

        RuleFor(x => x.PeopleAttitude)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.LONG_TITLE_LENGTH);

        RuleFor(x => x.AnimalAttitude)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.LONG_TITLE_LENGTH);

        RuleFor(x => x.Health)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.LONG_TITLE_LENGTH);

        RuleFor(x => x.Height).GreaterThanWithError(0);

        // value-objects.
        RuleFor(x => x.Place).MustBeValueObject(Place.Create);
        RuleFor(x => x.ContactNumber).MustBeValueObject(contactNumber => PhoneNumber.Create(contactNumber));
        RuleFor(x => x.VolunteerPhoneNumber).MustBeValueObject(volunteerPhoneNumber => PhoneNumber.Create(volunteerPhoneNumber));
        RuleFor(x => x.Weight).MustBeValueObject(Weight.Create);
        RuleFor(x => new { x.City, x.Street, x.Building, x.Postcode }).MustBeValueObject(x => Address.Create(x.City, x.Street, x.Building, x.Postcode));
    }
}