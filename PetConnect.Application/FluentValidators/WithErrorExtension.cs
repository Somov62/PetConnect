using FluentValidation;
using PetConnect.Domain.Common;
using System.Text.Json;

namespace PetConnect.Application.FluentValidators;

/// <summary>
/// Класс-расширение для библиотеки FluentValidations.
/// Это всё нужно для того, чтобы результат валидации содержал в ошибках JSONы класса <see cref="Error"/>, 
/// потому что их использует доменная модель и конверт API.
/// </summary>
public static class WithErrorExtension
{
    /// <summary>
    /// Метод, позволяющий подписать ошибку с помощью класса <see cref="Error"/>, который возвращают некоторые функции валидации.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Error error)
    {
        ArgumentNullException.ThrowIfNull(rule);
        rule.WithMessage(JsonSerializer.Serialize(error));
        return rule;
    }
}
