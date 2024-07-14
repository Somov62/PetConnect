using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;

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
    private Weight(float kilograms) => Kilograms = kilograms;

    /// <summary>
    /// Создает value-object места.
    /// </summary>
    /// <param name="weight">  Вес животного в килограммах. </param>
    public static Result<Weight, Error> Create(float weight)
    {
        if (weight <= 0)
            return Errors.General.ValueIsInvalid(nameof(weight), "Попытка передать отрицательный вес");

        return new Weight(weight);
    }
}

