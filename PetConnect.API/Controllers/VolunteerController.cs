using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using PetConnect.Application.Features.Volunteers.CreatePet;
using PetConnect.Application.Features.Volunteers.CreateVolunteer;
using PetConnect.Application.Features.Volunteers.UploadPhoto;
using PetConnect.Domain.Common;

namespace PetConnect.API.Controllers;

/// <summary>
/// Контроллер для взаимодействия с сущностями животных.
/// </summary>
[Route("[controller]")]
public partial class VolunteerController : ApplicationController
{
    /// <summary>
    /// Добавляет информацию о волонтере в систему.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        [FromServices] CreateVolunteerHandler createVolunteerService,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken cancellationToken)
    {
        var idResult = await createVolunteerService.Execute(request, cancellationToken);

        if (idResult.IsFailure)
            return BadRequest(idResult.Error);

        return Ok(idResult.Value);
    }


    /// <summary>
    /// Добавляет информацию о животном в систему.
    /// </summary>
    [HttpPost("pet")]
    public async Task<ActionResult<Guid>> Create(
        [FromServices] CreatePetHandler createPetService,
        [FromBody] CreatePetRequest request,
        CancellationToken cancellationToken)
    {
        var idResult = await createPetService.Execute(request, cancellationToken);

        if (idResult.IsFailure)
            return BadRequest(idResult.Error);

        return Ok(idResult.Value);
    }


    /// <summary>
    ///Загружает фотографию волонтеру .
    /// </summary>
    [HttpPost("photo")]
    public async Task<ActionResult> UploadPhoto(
        [FromForm] UploadVolunteerPhotoRequest request,
        [FromServices] UploadVolunteerPhotoHandler handler,
        CancellationToken cancellationToken)
    {
        var path = await handler.Handle(request, cancellationToken);

        return path.IsSuccess ?
            Ok(path.Value) :
            BadRequest(path.Error);
    }

    /// <summary>
    ///Загружает фотографию волонтеру.
    /// </summary>
    [HttpGet("photo")]
    public async Task<ActionResult> GetPhoto(
        string name,
        [FromServices] IMinioClient client,
        CancellationToken cancellationToken)
    {
        var presignedGetObjectArgs = new PresignedGetObjectArgs()
            .WithBucket("images")
            .WithObject(name)
            .WithExpiry(60*60*24);
        
        var url = await client.PresignedGetObjectAsync(presignedGetObjectArgs);
        return Ok(url);
    }
}

