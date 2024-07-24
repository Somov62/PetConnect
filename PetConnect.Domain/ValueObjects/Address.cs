using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;

namespace PetConnect.Domain.ValueObjects;

/// <summary>
/// Value-object адреса.
/// </summary>
public record Address
{
    private Address(string city, string street, string building, string postcode)
    {
        City = city;
        Street = street;
        Building = building;
        Postcode = postcode;
    }

    /// <summary>
    /// Город.
    /// </summary>
    public string City { get; }

    /// <summary>
    /// Улица.
    /// </summary>
    public string Street { get; }

    /// <summary>
    /// Дом/строение.
    /// </summary>
    public string Building { get; }

    /// <summary>
    /// Почтовый индекс.
    /// </summary>
    public string Postcode { get; }

    #region restrictions ограничения
    private const int MAX_CITY_LENGTH = 100;

    private const int MAX_STREET_LENGTH = 100;

    private const int MAX_BUILDING_LENGTH = 100;

    private const int POSTCODE_LENGTH = 6; 
    #endregion

    /// <summary>
    /// Создает value-object заданного адреса.
    /// </summary>
    public static Result<Address, Error> Create(string city, string street, string building, string postcode)
    {
        city = city?.Trim()!;
        if (string.IsNullOrWhiteSpace(city))
            return Errors.General.ValueIsRequired(nameof(city));

        if (city.Length > MAX_CITY_LENGTH)
            return Errors.General.InvalidLength(nameof(city));


        street = street?.Trim()!;
        if (string.IsNullOrWhiteSpace(street))
            return Errors.General.ValueIsRequired(nameof(street));

        if (street.Length > MAX_STREET_LENGTH)
            return Errors.General.InvalidLength(nameof(street));


        building = building?.Trim()!;
        if (string.IsNullOrWhiteSpace(building))
            return Errors.General.ValueIsRequired(nameof(building));

        if (building.Length > MAX_BUILDING_LENGTH)
            return Errors.General.InvalidLength(nameof(building));


        postcode = postcode?.Trim()!;
        if (string.IsNullOrWhiteSpace(postcode))
            return Errors.General.ValueIsRequired(nameof(postcode));

        if (postcode.Length != POSTCODE_LENGTH)
            return Errors.General.InvalidLength(nameof(postcode));

        return new Address(city, street, building, postcode);
    }
}