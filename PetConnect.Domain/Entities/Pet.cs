using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;
using PetConnect.Domain.ValueObjects;
using Entity = PetConnect.Domain.Common.Entity;

namespace PetConnect.Domain.Entities;

/// <summary>
/// Модель объявления о животном.
/// </summary>
public class Pet : Entity
{
    /// <summary>
    /// Пустой конструктор для DbContext.
    /// </summary>
    private Pet() { }

    /// <summary>
    /// Основной конструктор.
    /// </summary>
    private Pet(
        string nickname,
        string description,
        DateTimeOffset birthDate,
        string breed,
        string color,
        Place place,
        Address address,
        bool castration,
        string peopleAttitude,
        string animalAttitude,
        string health,
        bool onlyOneInFamily,
        int? height,
        Weight weight,
        PhoneNumber contactNumber,
        PhoneNumber volunteerPhoneNumber,
        bool onTreatment,
        DateTimeOffset createdDate)
    {
        Nickname = nickname;
        Description = description;
        BirthDate = birthDate;
        Breed = breed;
        Color = color;
        Place = place;
        Address = address;
        Castration = castration;
        PeopleAttitude = peopleAttitude;
        AnimalAttitude = animalAttitude;
        Health = health;
        OnlyOneInFamily = onlyOneInFamily;
        Height = height;
        Weight = weight;
        ContactPhoneNumber = contactNumber;
        VolunteerPhoneNumber = volunteerPhoneNumber;
        OnTreatment = onTreatment;
        CreatedDate = createdDate;
    }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Nickname { get; private set; } = string.Empty;

    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; private set; } = string.Empty;

    /// <summary>
    /// Порода.
    /// </summary>
    public string Breed { get; private set; } = string.Empty;

    /// <summary>
    /// Окрас.
    /// </summary>
    public string Color { get; private set; } = string.Empty;

    /// <summary>
    /// Отношение к людям.
    /// </summary>
    public string PeopleAttitude { get; private set; } = string.Empty;

    /// <summary>
    /// Отношение к животным.
    /// </summary>
    public string AnimalAttitude { get; private set; } = string.Empty;

    /// <summary>
    /// Подробное описание состояния здоровья.
    /// </summary>
    public string Health { get; private set; } = string.Empty;



    /// <summary>
    /// Кастрация/стерилизация.
    /// </summary>
    public bool Castration { get; private set; }

    /// <summary>
    /// Отметка о том, что данное животное должно быть единственным в семье.
    /// </summary>
    public bool OnlyOneInFamily { get; private set; }

    /// <summary>
    /// Отметка о том, что животное на данный момент находится на лечении.
    /// </summary>
    public bool OnTreatment { get; private set; }



    /// <summary>
    /// Рост в сантиметрах.
    /// </summary>
    public int? Height { get; private set; }



    /// <summary>
    /// Место нахождения.
    /// </summary>
    public Place Place { get; private set; } = default!;

    /// <summary>
    /// Адрес.
    /// </summary>
    public Address Address { get; private set; } = default!;

    /// <summary>
    /// Вес.
    /// </summary>
    public Weight Weight { get; private set; } = default!;

    /// <summary>
    /// Номер телефона для связи.
    /// </summary>
    public PhoneNumber ContactPhoneNumber { get; private set; } = default!;

    /// <summary>
    /// Номер телефона ответственного волонтера.
    /// </summary>
    public PhoneNumber VolunteerPhoneNumber { get; private set; } = default!;



    /// <summary>
    /// День рождения.
    /// </summary>
    public DateTimeOffset BirthDate { get; private set; }

    /// <summary>
    /// Дата создания сущности.
    /// </summary>
    public DateTimeOffset CreatedDate { get; private set; }



    /// <summary>
    /// Список имеющихся вакцин для внешнего использования.
    /// </summary>
    public IReadOnlyList<Vaccination> Vaccinations => _vaccinations;
    /// <summary>
    /// Список имеющихся вакцин для внутреннего использования.
    /// </summary>
    private readonly List<Vaccination> _vaccinations = [];



    /// <summary>
    /// Список фотографий для внешнего использования.
    /// </summary>
    public IReadOnlyList<Photo> Photos => _photos;
    /// <summary>
    /// Список фотографий для внутреннего использования.
    /// </summary>
    private readonly List<Photo> _photos = [];

    #region restrictions ограничения
    public const int MAX_NICKNAME_LENGTH = 100;
    public const int MAX_BREED_LENGTH = 100;
    public const int MAX_COLOR_LENGTH = 100;
    #endregion

    /// <summary>
    /// Создание животного с валидацией.
    /// </summary>
    public static Result<Pet, Error> Create(
        string nickname,
        string description,
        DateTimeOffset birthDate,
        string breed,
        string color,
        Place place,
        Address address,
        bool castration,
        string peopleAttitude,
        string animalAttitude,
        string health,
        bool onlyOneInFamily,
        int? height,
        Weight weight,
        PhoneNumber contactNumber,
        PhoneNumber volunteerPhoneNumber,
        bool onTreatment
        )
    {
        Result<string, Error> e;

        if ((e = StringHelper.HasPayload(ref nickname, maxLength: MAX_NICKNAME_LENGTH)) 
            .IsFailure) return e.Error;

        if ((e = StringHelper.HasPayload(ref breed, maxLength: MAX_BREED_LENGTH))
            .IsFailure) return e.Error;

        if ((e = StringHelper.HasPayload(ref color, maxLength: MAX_COLOR_LENGTH))
            .IsFailure) return e.Error;

        if ((e = StringHelper.HasPayload(ref peopleAttitude, maxLength: Constraints.LONG_TITLE_LENGTH))
            .IsFailure) return e.Error;

        if ((e = StringHelper.HasPayload(ref animalAttitude, maxLength: Constraints.LONG_TITLE_LENGTH))
            .IsFailure) return e.Error;

        if ((e = StringHelper.HasPayload(ref health, maxLength: Constraints.LONG_TITLE_LENGTH))
            .IsFailure) return e.Error;

        if ((e = StringHelper.HasPayload(ref description, maxLength: Constraints.LONG_TITLE_LENGTH))
            .IsFailure) return e.Error;

        if (birthDate > DateTimeOffset.UtcNow)
            return Errors.General.ValueIsInvalid(nameof(birthDate), "Дата опережает текущую.");

        return new Pet(
            nickname,
            description,
            birthDate,
            breed,
            color,
            place,
            address,
            castration,
            peopleAttitude,
            animalAttitude,
            health,
            onlyOneInFamily,
            height,
            weight,
            contactNumber,
            volunteerPhoneNumber,
            onTreatment,
            DateTime.Now);
    }
}

