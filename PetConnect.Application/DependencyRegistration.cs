using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetConnect.Application.Features.Volunteers.CreatePet;
using PetConnect.Application.Features.Volunteers.CreateVolunteer;
using PetConnect.Application.Features.Volunteers.UploadPhoto;

namespace PetConnect.Application;

/// <summary>
/// Регистрация зависимостей слоя Application.
/// </summary>
public static class DependencyRegistration
{
    /// <summary>
    /// Регистрация зависимостей слоя Application.
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services) =>
        services
            .AddServices()
            .AddValidatorsFromAssembly(typeof(DependencyRegistration).Assembly);


    /// <summary>
    /// Регистрация сервисов.
    /// </summary>
    private static IServiceCollection AddServices(this IServiceCollection services) =>
        services
            .AddScoped<CreatePetHandler>()
            .AddScoped<CreateVolunteerHandler>()
            .AddScoped<UploadVolunteerPhotoHandler>()
            ;
}
