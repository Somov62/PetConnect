using FluentValidation;
using PetConnect.Application.FluentValidators;
using PetConnect.Domain.Common;
using PetConnect.Domain.Entities;
using PetConnect.Domain.ValueObjects;

namespace PetConnect.Application.Features.Volunteers.CreatePet;

/// <summary>
/// ДТО для запроса на создание животного.
/// </summary>
/// <param name="VolunteerId"> Уникальный идентификатор волонтера, от лица которого публикуется объявление. </param>
/// <param name="Nickname"> Имя животного. </param>
/// <param name="Description"> Описание. </param>
/// <param name="Breed"> Порода. </param>
/// <param name="Color"> Окрас. </param>
/// <param name="PeopleAttitude"> Отношение животного к людям. </param>
/// <param name="AnimalAttitude"> Отношение животного к другим животным. </param>
/// <param name="Health"> Информация о здоровье животного. </param>
/// <param name="Place"> Текущее место расположения. </param>
/// <param name="City"> Адрес (город) </param>
/// <param name="Street"> Адрес (улица) </param>
/// <param name="Building"> Адрес (дом/строение) </param>
/// <param name="Postcode"> Адрес (почтовый индекс) </param>
/// <param name="ContactNumber"> Телефон человека, который содержит животное на данный момент. </param>
/// <param name="VolunteerPhoneNumber"> Телефон ответственного за это животное волонтёра. </param>
/// <param name="Castration"> Кастрировано ли животное. </param>
/// <param name="OnlyOneInFamily"> Отметка о том, что данное животное должно быть единственным в семье. </param>
/// <param name="OnTreatment"> Отметка о том, что животное на данный момент находится на лечении. </param>
/// <param name="Height"> Рост в сантиметрах. </param>
/// <param name="Weight"> Вес в килограммах. </param>
/// <param name="BirthDate"> Дата рождения. </param>
public record CreatePetRequest(
        Guid VolunteerId,
        string Nickname,
        string Description,
        string Breed,
        string Color,
        string PeopleAttitude,
        string AnimalAttitude,
        string Health,
        string Place,
        string City,
        string Street,
        string Building,
        string Postcode,
        string ContactNumber,
        string VolunteerPhoneNumber,
        bool Castration,
        bool OnlyOneInFamily,
        bool OnTreatment,
        int? Height,
        float Weight,
        DateTimeOffset BirthDate
    );

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