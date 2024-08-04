using FluentValidation;
using PetConnect.Application.FluentValidators;
using PetConnect.Domain.Common;

namespace PetConnect.Application.Features.Volunteers.CreateVolunteer;

/// <summary>
/// Валидация для класса <see cref="CreateVolunteerRequest"/>.
/// </summary>
public class CreateVolunteerRequestValidator : AbstractValidator<CreateVolunteerRequest>
{
    public CreateVolunteerRequestValidator()
    {
        RuleFor(v => v.Name)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.SHORT_TITLE_LENGTH)
            .WithError(Errors.General.InvalidLength());

        RuleFor(v => v.Description)
            .NotEmptyWithError()
            .MaximumLengthWithError(Constraints.LONG_TITLE_LENGTH);

        RuleFor(v => v.YearsExperience)
            .GreaterThanWithError(-1);

        RuleFor(v => v.SuccessFoundHomeForPetCount)
            .GreaterThanWithError(-1)
            .When(x => x != null);

        RuleFor(v => v.DonationInfo!)
            .MaximumLengthWithError(Constraints.LONG_TITLE_LENGTH)
            .When(x => x != null);
    }
}