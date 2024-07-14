using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;
using System.Text.RegularExpressions;

namespace PetConnect.Domain.ValueObjects;

/// <summary>
/// Value-object для номеров телефонов.
/// </summary>
public partial record PhoneNumber
{
    private PhoneNumber(string number) => Number = number;

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string Number { get; }

    /// <summary>
    /// Создает value-object номера телефона.
    /// </summary>
    public static Result<PhoneNumber, Error> Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Errors.General.ValueIsRequired("номер телефона");

        if (!IsPhoneNumber().IsMatch(input))
            return Errors.General.ValueIsInvalid("номер телефона", "не соответствует маске российских номеров");

        return new PhoneNumber(input);
    }

    [GeneratedRegex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}")]
    private static partial Regex IsPhoneNumber();
}
