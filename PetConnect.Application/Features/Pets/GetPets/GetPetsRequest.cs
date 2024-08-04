using FluentValidation;
using PetConnect.Application.FluentValidators;
using PetConnect.Domain.Common;

namespace PetConnect.Application.Features.Pets.GetPets;

/// <summary>
/// Параметры для запроса странички с животными.
/// </summary>
public record GetPetsRequest(
    string? Nickname,
    string? Breed,
    string? Color,
    int Size = 10,
    int Page = 1);


/// <summary>
/// Валидация для класса <see cref="GetPetsRequest"/>.
/// </summary>
public class GetPetsRequestValidator : AbstractValidator<GetPetsRequest>
{
    public GetPetsRequestValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanWithError(0)
            .WithError(Errors.General.ValueIsInvalid(
                "{PropertyName}",
                "пагинация начинается с 1"));

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .WithError(Errors.General.ValueIsInvalid(
                "{PropertyName}",
                "не меньше одного объекта в странице"));
    }
}