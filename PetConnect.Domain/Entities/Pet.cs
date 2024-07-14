﻿using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;
using PetConnect.Domain.ValueObjects;

namespace PetConnect.Domain.Entities;

/// <summary>
/// Модель объявления о животном.
/// </summary>
public class Pet
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
    /// Уникальный идентификатор.
    /// </summary>
    public Guid Id { get; private set; }



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
    public string PeopleAttitude { get; private set; }

    /// <summary>
    /// Отношение к животным.
    /// </summary>
    public string AnimalAttitude { get; private set; }

    /// <summary>
    /// Подробное описание состояния здоровья.
    /// </summary>
    public string Health { get; private set; }



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
    public Place Place { get; private set; }

    /// <summary>
    /// Адрес.
    /// </summary>
    public Address Address { get; private set; }

    /// <summary>
    /// Вес.
    /// </summary>
    public Weight Weight { get; private set; } = default!;

    /// <summary>
    /// Номер телефона для связи.
    /// </summary>
    public PhoneNumber ContactPhoneNumber { get; private set; }

    /// <summary>
    /// Номер телефона ответственного волонтера.
    /// </summary>
    public PhoneNumber VolunteerPhoneNumber { get; private set; }



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


    /// <summary>
    /// Максимальная длина поля <see cref="Nickname"/>
    /// </summary>
    private const int MAX_NICKNAME_LENGTH = 100;


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
        if (string.IsNullOrWhiteSpace(nickname) || nickname.Length > MAX_NICKNAME_LENGTH)
            return Errors.General.InvalidLength(nameof(nickname));

        if (string.IsNullOrWhiteSpace(breed))
            return Errors.General.ValueIsRequired(nameof(breed));

        if (string.IsNullOrWhiteSpace(color))
            return Errors.General.ValueIsRequired(nameof(color));

        if (string.IsNullOrWhiteSpace(peopleAttitude))
            return Errors.General.ValueIsRequired(nameof(peopleAttitude));

        if (string.IsNullOrWhiteSpace(animalAttitude))
            return Errors.General.ValueIsRequired(nameof(animalAttitude));

        if (string.IsNullOrWhiteSpace(health))
            return Errors.General.ValueIsRequired(nameof(health));

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
