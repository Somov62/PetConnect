namespace PetConnect.Domain.ValueObjects;

/// <summary>
/// Value-object веса для указания веса животного.
/// </summary>
public record Weight
{
    /// <summary>
    /// Вес в граммах.
    /// </summary>
    public float Kilograms { get; set; }

    /// <summary>
    /// Указать вес животного в килограммах.
    /// </summary>
    /// <param name="kilograms"></param>
    public Weight(float kilograms)
    {
        Kilograms = kilograms;
    }
}

