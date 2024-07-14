namespace PetConnect.Domain.ValueObjects;

public record Weight
{
    public Weight()
    {
        
    }

    /// <summary>
    /// Вес в граммах.
    /// </summary>
    public int Grams { get; set; }

    /// <summary>
    /// Указать вес животного в килограммах.
    /// </summary>
    /// <param name="kilograms"></param>
    public Weight(float kilograms)
    {
        Grams = (int)(kilograms * 1000);
    }
}

