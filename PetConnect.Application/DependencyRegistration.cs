using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace PetConnect.Application;

/// <summary>
/// Регистрация зависимостей слоя Application.
/// </summary>
public static class DependencyRegistration
{
    /// <summary>
    /// Регистрация зависимостей слоя Application.
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Сервисы.
        services.AddScoped<PetsService>();

        // Fluent validators.
        services.AddValidatorsFromAssembly(typeof(DependencyRegistration).Assembly);
        return services;
    }
}
