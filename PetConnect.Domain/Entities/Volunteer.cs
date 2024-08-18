using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;
using PetConnect.Domain.ValueObjects;
using Entity = PetConnect.Domain.Common.Entity;

namespace PetConnect.Domain.Entities;

/// <summary>
/// Модель волонтёра.
/// </summary>
public class Volunteer : Entity
{
    private Volunteer() { }

    public Volunteer(
        string name,
        string description,
        string? donationInfo,
        int years,
        int? successFoundHomeForPetCount,
        bool fromShelter,
        SocialMedias socialMedias)
    {
        Name = name;
        Description = description;
        DonationInfo = donationInfo;
        YearsExperience = years;
        SuccessFoundHomeForPetCount = successFoundHomeForPetCount;
        FromShelter = fromShelter;
        SocialMedias = socialMedias;
    }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string Description { get; private set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string? DonationInfo { get; private set; } = string.Empty;



    /// <summary>
    /// 
    /// </summary>
    public int YearsExperience  { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int? SuccessFoundHomeForPetCount { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public bool FromShelter { get; private set; }


    /// <summary>
    /// Группа ссылок на сторонние ресурсы, соцсети.
    /// </summary>
    public SocialMedias SocialMedias { get; private set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public IReadOnlyList<Photo> Photos => _photos;
    /// <summary>
    /// 
    /// </summary>
    private readonly List<Photo> _photos = [];


    /// <summary>
    /// 
    /// </summary>
    public IReadOnlyList<Pet> Pets => _pets;
    /// <summary>
    /// 
    /// </summary>
    private readonly List<Pet> _pets = [];


    /// <summary>
    /// Опубликовать объявление о животном от лица волонтёра.
    /// </summary>
    public void PublishPet(Pet pet) => _pets.Add(pet);

    /// <summary>
    /// Разрешенное количество фотографий.
    /// </summary>
    public const int PHOTO_COUNT_LIMIT = 5;
    /// <summary>
    /// Добавляет фото волонтеру.
    /// </summary>
    public Result<Unit, Error> AddPhoto(Photo photo)
    {
        if (_photos.Count >= PHOTO_COUNT_LIMIT)
            return Errors.Volunteers.PhotoCountLimit();

        _photos.Add(photo);

        return new();
    }


    /// <summary>
    /// Создание волонтера с валидацией.
    /// </summary>
    public static Result<Volunteer, Error> Create(
      string name,
      string description,
      int yearsExperience,
      int? successFoundHomeForPetCount,
      string? donationInfo,
      bool fromShelter,
      SocialMedias socialMedias)
    {
        Result<string, Error> e;

        if ((e = StringHelper.HasPayload(ref name, maxLength: Constraints.SHORT_TITLE_LENGTH))
            .IsFailure) return e.Error;

        if ((e = StringHelper.HasPayload(ref description, maxLength: Constraints.LONG_TITLE_LENGTH))
            .IsFailure) return e.Error;

        if (yearsExperience < 0)
            return Errors.General.ValueIsInvalid(nameof(yearsExperience), "Не может быть отрицательным.");

        if (successFoundHomeForPetCount < 0)
            return Errors.General.ValueIsInvalid(nameof(successFoundHomeForPetCount), "Не может быть отрицательным.");

        if (donationInfo?.Length > Constraints.LONG_TITLE_LENGTH)
            return Errors.General.InvalidLength(nameof(donationInfo));

        return new Volunteer(
            name,
            description,
            donationInfo,
            yearsExperience,
            successFoundHomeForPetCount,
            fromShelter,
            socialMedias);
    }
}