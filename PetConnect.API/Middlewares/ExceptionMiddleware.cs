using PetConnect.API.Helpers;
using PetConnect.Domain.Common;
using System.Net;

namespace PetConnect.API.Middlewares;

/// <summary>
/// Middleware для обработки исключений системы.
/// </summary>
public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    /// <summary>
    /// Делегат следующего шага обработки запроса.
    /// </summary>
    private readonly RequestDelegate _next = next;

    /// <summary>
    /// Логгер для фиксирования исключений.
    /// </summary>
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    /// <summary>
    /// Обертка для отлавливания исключений.
    /// </summary>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var error = new Error("server.internal", ex.Message);
            await context.Response.WriteAsJsonAsync(Envelope.Error(error));
        }
    }
}
