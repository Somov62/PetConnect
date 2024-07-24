using Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using PetConnect.Application;

namespace PetConnect.API.Controllers;

/// <summary>
/// Контроллер для взаимодействия с сущностями животных.
/// </summary>
[Route("[controller]")]
public class PetController(PetsService petService) : ApplicationController
{
    /// <summary>
    /// Добавляет информацию о животном в систему.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreatePetRequest request, CancellationToken cancellationToken)
    {
        var idResult = await petService.CreatePet(request, cancellationToken);

        if (idResult.IsFailure)
            return BadRequest(idResult.Error);

        return Ok(idResult.Value);
    } 
}