using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace PetConnect.API.Helpers;

/// <summary>
/// Глобальный обработчик исключений.
/// </summary>
public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger = logger;

    /// <summary>
    /// Обработка исключения, путем возврата пользователю красивого ответа 
    /// в виде кода ошибки и сообщения с причиной ошибки.
    /// </summary>
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var exceptionMessage = exception.Message;

        _logger.LogError(
            "Error Message: {exceptionMessage}, Time of occurrence {time}",
            exceptionMessage, DateTime.UtcNow);

        var response = new Response("value.invalid", exceptionMessage);

        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}

/// <summary>
/// Ответ пользователю о случившейся ошибке.
/// </summary>
/// <param name="Code"> Код ошибки. </param>
/// <param name="Message"> Сообщение о причинах. </param>
public record Response(string Code, string Message);
