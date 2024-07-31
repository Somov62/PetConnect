using Microsoft.AspNetCore.Mvc;
using PetConnect.Application.Features.Volunteers.CreatePet;
using PetConnect.Application.Features.Volunteers.CreateVolunteer;

namespace PetConnect.API.Controllers;

[Route("[controller]")]
public partial class VolunteerController : ApplicationController
{
    /// <summary>
    /// 
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        [FromServices] CreateVolunteerService createVolunteerService,
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
        [FromServices] CreatePetService createPetService,
        [FromBody] CreatePetRequest request,
        CancellationToken cancellationToken)
    {
        var idResult = await createPetService.Execute(request, cancellationToken);

        if (idResult.IsFailure)
            return BadRequest(idResult.Error);

        return Ok(idResult.Value);
    }
}

