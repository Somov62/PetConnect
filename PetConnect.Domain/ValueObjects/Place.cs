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
    /// На передержке
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

    public Place(string value) => Value = value;


    /// <summary>
    /// Создает новый вариант места.
    /// </summary>
    public static Place Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentNullException(nameof(input));

        var place = input.Trim().ToUpper();

        if (_all.Any(p => p.Value == place) == false)
        {
            throw new ArgumentException("Указанный вариант уже существует в виде свойства.");
        }

        return new(place);
    }
}