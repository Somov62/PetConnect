using CSharpFunctionalExtensions;
using FluentValidation;
using PetConnect.Domain.Common;

namespace PetConnect.Application.FluentValidators;

/// <summary>
/// Класс-расширение с кастомными валидаторами для библиотеки FluentValidations.
/// </summary>
public static class CustomValidators
{
    /// <summary>
    /// Универсальный метод для валидации value-object, у которого есть фабричный метод создания.
    /// Валидация таких объектов основана на валидации внутри фабричного метода.
    /// </summary>
    public static IRuleBuilderOptions<T, TElement> MustBeValueObject<T, TElement, TValueObject>(
            this IRuleBuilder<T, TElement> ruleBuilder,
            Func<TElement, Result<TValueObject, Error>> factoryMethod
        ) =>
            (IRuleBuilderOptions<T, TElement>)ruleBuilder.Custom((value, context) =>
            {
                Result<TValueObject, Error> result = factoryMethod(value);

                if (result.IsSuccess)
                    return;

                context.AddFailure(result.Error.Serialize());
            });
}