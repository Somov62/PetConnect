namespace PetConnect.Application.Features.Volunteers.CreateVolunteer;

/// <summary>
/// 
/// </summary>
/// <param name="Name"></param>
/// <param name="Description"></param>
/// <param name="DonationInfo"></param>
/// <param name="YearsExperience"></param>
/// <param name="SuccessFoundHomeForPetCount"></param>
/// <param name="FromShelter"></param>
/// <param name="SocialMedias"></param>
public record CreateVolunteerRequest(
    string Name,
    string Description,
    string DonationInfo,
    int YearsExperience,
    int SuccessFoundHomeForPetCount,
    bool FromShelter,
    SocialMediasDto SocialMedias
    );

/// <summary>
/// 
/// </summary>
/// <param name="Telegram"></param>
/// <param name="VK"></param>
/// <param name="WhatsApp"></param>
/// <param name="SocialMedias"></param>
public record SocialMediasDto(
    string Telegram,
    string VK,
    string WhatsApp,
    List<SocialMediaDto> SocialMedias
    );

/// <summary>
/// 
/// </summary>
/// <param name="Link"></param>
/// <param name="Title"></param>
public record SocialMediaDto(
     string Link,
     string Title
    );
