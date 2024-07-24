using Contracts.Pets.Requests;
using Microsoft.AspNetCore.Mvc;
using PetConnect.Application.Services;

namespace PetConnect.API.Controllers;

/// <summary>
/// Контроллер для взаимодействия с сущностями животных.
/// </summary>
[Route("[controller]")]
public class PetController(PetsService petsService) : ApplicationController
{
    /// <summary>
    /// Добавляет информацию о животном в систему.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreatePetRequest request, CancellationToken cancellationToken)
    {
        var idResult = await petsService.CreatePet(request, cancellationToken);

        if (idResult.IsFailure)
            return BadRequest(idResult.Error);

        return Ok(idResult.Value);
    }

    /// <summary>
    /// 
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetByPage([FromQuery] GetPetsByPageRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
            return BadRequest("Не указаны параметры пагинации");

        var response = await petsService.GetByPage (request, cancellationToken);

        return Ok(response);
    }
}