using CSharpFunctionalExtensions;
using PetConnect.Abstractions;
using PetConnect.Domain.Common;
using PetConnect.Domain.Entities;

namespace PetConnect.Application.Features.Volunteers.UploadPhoto;

public class UploadVolunteerPhotoHandler(IMinioProvider minio, IVolunteersRepository repository)
{
    public async Task<Result<string, Error>> Handle(
        UploadVolunteerPhotoRequest request, CancellationToken cancellationToken)
    {

        var volunteerResult = await repository.GetById(request.VolunteerId, cancellationToken);
        if (volunteerResult.IsFailure)
            return volunteerResult.Error;
        var volunteer = volunteerResult.Value;

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.File.FileName);

        var photoResult = Photo.Create(fileName, false);
        if (photoResult.IsFailure)
            return photoResult.Error;
        var photo = photoResult.Value;

        var addPhotoResult = volunteer.AddPhoto(photo);
        if (addPhotoResult.IsFailure)
            return addPhotoResult.Error;

        Result<string, Error> uploadPhotoToStorageResult;
        using var stream = request.File.OpenReadStream();
        {
            uploadPhotoToStorageResult = await minio.UploadPhotoAsync(stream, fileName, cancellationToken);
        }
        if (uploadPhotoToStorageResult.IsFailure)
            return uploadPhotoToStorageResult.Error ?? 
            Errors.Database.SaveFailure("Не удалось загрузить фото в хранилище.");

        var savePhotoResult = await repository.Save(cancellationToken);
        if (savePhotoResult.IsFailure)
        {
            await minio.RemovePhotoAsync(fileName, cancellationToken);
            return savePhotoResult.Error;
        }    
     
        return fileName;
    }
}
