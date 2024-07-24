using Contracts.Pets.Requests;
using FluentValidation;
using PetConnect.Domain.Common;

namespace PetConnect.Application.FluentValidators.Pets;

/// <summary>
/// Валидация для класса <see cref="GetPetsByPageRequest"/>.
/// </summary>
public class GetPetsByPageRequestValidator : AbstractValidator<GetPetsByPageRequest>
{
    public GetPetsByPageRequestValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0)
            .WithError(Errors.General.ValueIsInvalid(
                nameof(GetPetsByPageRequest.Page), 
                "пагинация начинается с 1"));

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .WithError(Errors.General.ValueIsInvalid(
                nameof(GetPetsByPageRequest.Size),
                "не меньше одного объекта в странице"));
    }
}
