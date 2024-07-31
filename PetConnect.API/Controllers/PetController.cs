using Microsoft.AspNetCore.Mvc;
using PetConnect.Application.Features.Pets.GetPets;
using PetConnect.Infrastructure.Queries.Pets;

namespace PetConnect.API.Controllers;

/// <summary>
/// Контроллер для взаимодействия с сущностями животных.
/// </summary>
[Route("[controller]")]
public class PetController : ApplicationController
{
    

    /// <summary>
    /// 
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetByPage(
        [FromServices] GetPetsQuery query,
        [FromQuery] GetPetsRequest request, 
        CancellationToken cancellationToken)
    {
        if (request == null)
            return BadRequest("Не указаны параметры пагинации");

        var response = await query.Execute(request, cancellationToken);

        return Ok(response);
    }
}