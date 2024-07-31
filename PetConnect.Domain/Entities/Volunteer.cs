using PetConnect.Domain.ValueObjects;

namespace PetConnect.Domain.Entities;

/// <summary>
/// Модель волонтёра.
/// </summary>
public class Volunteer
{
    private Volunteer() { }

    public Volunteer(
        string name,
        string description,
        string donationInfo,
        int years,
        int successFoundHomeForPetCount,
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
    /// Уникальный идентификатор.
    /// </summary>
    public Guid Id { get; private set; }



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
    public string DonationInfo { get; private set; } = string.Empty;



    /// <summary>
    /// 
    /// </summary>
    public int YearsExperience  { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int SuccessFoundHomeForPetCount { get; private set; }

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
    public void PublishPet(Pet pet)
    {
        _pets.Add(pet);
    }
}