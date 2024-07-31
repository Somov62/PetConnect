using FluentValidation;
using PetConnect.Application.FluentValidators;
using PetConnect.Domain.Common;

namespace PetConnect.Application.Features.Pets.GetPets;

/// <summary>
/// 
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
            .GreaterThan(0)
            .WithError(Errors.General.ValueIsInvalid(
                nameof(GetPetsRequest.Page),
                "пагинация начинается с 1"));

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .WithError(Errors.General.ValueIsInvalid(
                nameof(GetPetsRequest.Size),
                "не меньше одного объекта в странице"));
    }
}