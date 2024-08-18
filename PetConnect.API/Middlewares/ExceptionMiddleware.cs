using PetConnect.API.Contracts;
using PetConnect.Domain.Common;
using System.Net;

namespace PetConnect.API.Middlewares;

/// <summary>
/// Middleware для обработки исключений системы.
/// </summary>
public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    /// <summary>
    /// Обертка для отлавливания исключений.
    /// </summary>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var error = Errors.General.Internal(ex.Message);
            await context.Response.WriteAsJsonAsync(Envelope.Error(error));
        }
    }
}
