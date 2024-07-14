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
        if (string.IsNullOrWhiteSpace(place))
            return Errors.General.ValueIsRequired(nameof(place));

        place = place.Trim().ToUpper();

        if (_all.Any(p => p.Value == place) == false)
            return Errors.General.ValueIsInvalid(nameof(place));

        return new Place(place);
    }
}