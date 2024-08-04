using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;
using System.Runtime.CompilerServices;
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
    public static Result<PhoneNumber, Error> Create(string input, [CallerArgumentExpression(nameof(input))] string fieldName = "")
    {
        if (string.IsNullOrWhiteSpace(input))
            return Errors.General.ValueIsRequired(fieldName);

        if (!IsPhoneNumber().IsMatch(input))
            return Errors.General.ValueIsInvalid(fieldName, "не соответствует маске российских номеров");

        return new PhoneNumber(input);
    }

    [GeneratedRegex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}")]
    private static partial Regex IsPhoneNumber();
}
