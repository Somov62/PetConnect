using Microsoft.Extensions.DependencyInjection;
using PetConnect.Application.Features.Pets;
using PetConnect.Application.Features.Volunteers;
using PetConnect.Infrastructure.DbContexts;
using PetConnect.Infrastructure.Queries.Pets;
using PetConnect.Infrastructure.Repositories;

namespace PetConnect.Infrastructure;

/// <summary>
/// Регистрация зависимостей слоя Infrastructure.
/// </summary>
public static class DependencyRegistration
{
    /// <summary>
    /// Регистрация зависимостей слоя Infrastructure.
    /// </summary>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services
            .AddDataBase()
            .AddRepositories()
            .AddQueries();


    /// <summary>
    /// Регистрация контекстов бд.
    /// </summary>
    public static IServiceCollection AddDataBase(this IServiceCollection services) =>
        services
            .AddScoped<PetConnectReadDbContext>()
            .AddScoped<PetConnectWriteDbContext>()
            ;


    /// <summary>
    /// Регистрация реализаций репозиториев.
    /// </summary>
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
            .AddScoped<IPetsRepository, PetsRepository>()
            .AddScoped<IVolunteerRepository, VolunteerRepository>()
            ;


    /// <summary>
    /// Регистрация запросов на чтение.
    /// </summary>
    public static IServiceCollection AddQueries(this IServiceCollection services) =>
        services
            .AddScoped<GetPetsQuery>()
            ;
}
