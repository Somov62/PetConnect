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
    public const int MAX_CITY_LENGTH = 100;
    public const int MAX_STREET_LENGTH = 100;
    public const int MAX_BUILDING_LENGTH = 100;
    public const int POSTCODE_LENGTH = 6; 
    #endregion

    /// <summary>
    /// Создает value-object заданного адреса.
    /// </summary>
    public static Result<Address, Error> Create(string city, string street, string building, string postcode)
    {
        Result<string, Error> e;

        if ((e = StringHelper.HasPayload(ref city, maxLength: MAX_CITY_LENGTH))
            .IsFailure) return e.Error;

        if ((e = StringHelper.HasPayload(ref street, maxLength: MAX_STREET_LENGTH))
            .IsFailure) return e.Error;

        if ((e = StringHelper.HasPayload(ref building, maxLength: MAX_BUILDING_LENGTH))
            .IsFailure) return e.Error;

        if ((e = StringHelper.HasPayload(ref postcode))
            .IsFailure) return e.Error;

        if (postcode.Length != POSTCODE_LENGTH)
            return Errors.General.InvalidLength(nameof(postcode));

        return new Address(city, street, building, postcode);
    }
}