namespace PetConnect.Domain.ValueObjects;

/// <summary>
/// Value-object адреса.
/// </summary>
public record Address
{
    public Address()
    {
        
    }

    public Address(string city, string street, string building, string postcode)
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
}