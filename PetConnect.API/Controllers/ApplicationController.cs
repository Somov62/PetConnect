using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PetConnect.API.Helpers;
using PetConnect.Domain.Common;

namespace PetConnect.API.Controllers;

/// <summary>
/// Базовый контроллер.
/// </summary>
[ApiController]
public abstract class ApplicationController : ControllerBase
{
    /// <summary>
    /// Возвращает ответ с кодом 200, обёрнутый в конверт.
    /// </summary>
    public override OkObjectResult Ok([ActionResultObjectValue] object? value)
    {
        return base.Ok(Envelope.Ok(value));
    }

    /// <summary>
    /// Возвращает ответ с кодом 400, обёрнутый в конверт.
    /// </summary>
    [NonAction]
    public BadRequestObjectResult BadRequest([ActionResultObjectValue] Error error)
    {
        return base.BadRequest(Envelope.Error(error));
    }
}
