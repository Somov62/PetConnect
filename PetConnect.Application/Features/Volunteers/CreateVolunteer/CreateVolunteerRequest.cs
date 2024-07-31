namespace PetConnect.Application.Features.Volunteers.CreateVolunteer;

public record CreateVolunteerRequest(
    string Name,
    string Description,
    string DonationInfo,
    int YearsExperience,
    int SuccessFoundHomeForPetCount,
    bool FromShelter,
    SocialMediasDto SocialMedias
    );

public record SocialMediasDto(
    string Telegram,
    string VK,
    string WhatsApp,
    List<SocialMediaDto> SocialMedias
    );

public record SocialMediaDto(
     string Link,
     string Title
    );

