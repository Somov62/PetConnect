using System.Text.RegularExpressions;

namespace PetConnect.Domain.ValueObjects;

/// <summary>
/// Value-object для номеров телефонов.
/// </summary>
public record PhoneNumber
{
    private const string _phoneRegex = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7, 10}";
    private PhoneNumber(string number) => Number = number;

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string Number { get; }

    /// <summary>
    /// Создает value-object номера телефона.
    /// </summary>
    public static PhoneNumber Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentNullException(nameof(input));

        if (Regex.IsMatch(input, _phoneRegex))
            throw new ArgumentException();

        return new PhoneNumber(input);
    }
}