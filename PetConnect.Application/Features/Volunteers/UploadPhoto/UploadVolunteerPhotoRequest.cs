using Microsoft.AspNetCore.Http;

namespace PetConnect.Application.Features.Volunteers.UploadPhoto;
public record UploadVolunteerPhotoRequest(Guid VolunteerId, IFormFile File)
{

}
