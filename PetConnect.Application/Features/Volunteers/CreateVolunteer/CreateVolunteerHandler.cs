using CSharpFunctionalExtensions;
using PetConnect.Domain.Common;
using PetConnect.Domain.Entities;
using PetConnect.Domain.ValueObjects;

namespace PetConnect.Application.Features.Volunteers.CreateVolunteer;

/// <summary>
/// Сервис для работы с сущностью волонтера <see cref="Volunteer"/>
/// </summary>
public class CreateVolunteerHandler(IVolunteersRepository repository)
{
    /// <summary>
    /// Добавляет информацию о животном в систему.
    /// </summary>
    public async Task<Result<Guid, Error>> Execute(CreateVolunteerRequest request, CancellationToken cancellationToken)
    {
        // Инстанцируем value-objects.
        var socialMedias = SocialMedias.Create(request.SocialMedias.Telegram,
                                               request.SocialMedias.VK,
                                               request.SocialMedias.WhatsApp,
                                               request.SocialMedias.SocialMedias
                                                   .Select(social => SocialMedia.Create(social.Link, social.Title).Value)).Value;

        var volunteer = new Volunteer(request.Name,
                                      request.Description,
                                      request.DonationInfo,
                                      request.YearsExperience,
                                      request.SuccessFoundHomeForPetCount,
                                      request.FromShelter,
                                      socialMedias
                                      );

        await repository.Add(volunteer, cancellationToken);
        var saveResult = await repository.Save(cancellationToken);
        if (saveResult.IsFailure)
            return saveResult.Error;

        return volunteer.Id;
    }

}
