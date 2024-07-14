using System.Text.RegularExpressions;

namespace PetConnect.Domain.ValueObjects;

public record PhoneNumber
{
    private const string _phoneRegex = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7, 10}";

    public string Number { get; }

    private PhoneNumber(string number)
    {
        Number = number;
    }

    public static PhoneNumber Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentNullException(nameof(input));

        if (Regex.IsMatch(input, _phoneRegex))
            throw new ArgumentException();

        return new PhoneNumber(input);
    }
}