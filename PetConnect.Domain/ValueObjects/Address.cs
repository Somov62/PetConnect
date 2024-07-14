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


    /// <summary>
    /// Создает value-object заданного адреса.
    /// </summary>
    public static Result<Address, Error> Create(string city, string street, string building, string postcode)
    {
        if (string.IsNullOrWhiteSpace(city))
            return Errors.General.ValueIsRequired(nameof(city));

        if (string.IsNullOrWhiteSpace(street))
            return Errors.General.ValueIsRequired(nameof(street));

        if (string.IsNullOrWhiteSpace(building))
            return Errors.General.ValueIsRequired(nameof(building));

        if (string.IsNullOrWhiteSpace(postcode))
            return Errors.General.ValueIsRequired(nameof(postcode));

        return new Address(city, street, building, postcode);
    }
}