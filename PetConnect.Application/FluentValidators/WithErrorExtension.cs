using FluentValidation;
using PetConnect.Domain.Common;

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
        rule.WithMessage(error.Serialize());
        return rule;
    }


    /// <summary>
    /// Проверить на null или пустоту.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> NotEmptyWithError<T, TProperty>(
       this IRuleBuilder<T, TProperty> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .WithError(Errors.General.ValueIsRequired("{PropertyName}"));
    }

    /// <summary>
    /// Проверить на максимальную длину.
    /// </summary>
    public static IRuleBuilderOptions<T, string> MaximumLengthWithError<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        int maxLength)
    {
        return ruleBuilder
            .MaximumLength(maxLength)
            .WithError(Errors.General.InvalidLength("{PropertyName}"));
    }

    /// <summary>
    /// Проверить на то, что значение свойства больше заданного.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> GreaterThanWithError<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare)
        where TProperty : IComparable<TProperty>, IComparable
    {
        return ruleBuilder
            .GreaterThan(valueToCompare)
            .WithError(Errors.General.ValueIsInvalid("{PropertyName}", "Значение должно быть больше чем " + valueToCompare.ToString())); ;
    }

    /// <summary>
    /// Проверить на то, что значение свойства больше заданного.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty?> GreaterThanWithError<T, TProperty>(
    this IRuleBuilder<T, TProperty?> ruleBuilder, TProperty valueToCompare)
    where TProperty : struct, IComparable<TProperty>, IComparable
    {
        return ruleBuilder
            .GreaterThan(valueToCompare)
            .WithError(Errors.General.ValueIsInvalid("{PropertyName}", "Значение должно быть больше чем " + valueToCompare.ToString()));
    }

    /// <summary>
    /// Проверить на то, что значение свойства меньше заданного.
    /// </summary>
    public static IRuleBuilderOptions<T, TProperty> LessThanWithError<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare)
        where TProperty : IComparable<TProperty>, IComparable
    {
        return ruleBuilder
            .LessThan(valueToCompare)
            .WithError(Errors.General.InvalidLength("{PropertyName}"));
    }
}
