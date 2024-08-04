using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;

namespace PetConnect.Domain.ValueObjects;

/// <summary>
/// Value-object места, в котором находится животное.
/// </summary>
public record Place
{
    /// <summary>
    /// На лечении в больнице.
    /// </summary>
    public static readonly Place InHospital = new(nameof(InHospital).ToUpper());

    /// <summary>
    /// На передержке.
    /// </summary>
    public static readonly Place InTemporaryHome = new(nameof(InTemporaryHome).ToUpper());

    /// <summary>
    /// Все заготовленные варианты.
    /// </summary>
    private static readonly Place[] _all = [InHospital, InTemporaryHome];


    /// <summary>
    /// Значение.
    /// </summary>
    public string Value { get; }

    private Place(string value) => Value = value;


    /// <summary>
    /// Создает value-object места.
    /// </summary>
    public static Result<Place, Error> Create(string place)
    {
        Result<string, Error> e;
        if ((e = StringHelper.HasPayload(ref place)).IsFailure)
            return e.Error;

        place = place.ToUpper();

        if (_all.Any(p => p.Value == place) == false)
            return Errors.General.ValueIsInvalid(nameof(place), "Неопознанное место.");

        return new Place(place);
    }
}