using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetConnect.API.Contracts;
using PetConnect.Domain.Common;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;

namespace PetConnect.API.AutoFluentValidation;

/// <summary>
/// Конфигурация автоматической fluent валидации для эндпоинтов.
/// Конкретно здесь я переопределяю формат ответа валидатора, 
/// в котором он отправляет клиенту список ошибок.
/// </summary>
public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
{
    /// <summary>
    /// Оборачиваю информацию об ошибках в конверт <see cref="Envelope"/>.
    /// Это нужно для того, чтобы структура ответа во всех случаях была одинаковой.
    /// </summary>
    public IActionResult CreateActionResult(
        ActionExecutingContext context,
        ValidationProblemDetails? validationProblemDetails)
    {
        if (validationProblemDetails is null)
        {
            return new BadRequestObjectResult("Invalid error");
        }

        var errors = validationProblemDetails.Errors
            .SelectMany(pair => pair.Value)
            .Select(Error.Deserialize);

        return new BadRequestObjectResult(Envelope.Error(errors!));
    }
}
