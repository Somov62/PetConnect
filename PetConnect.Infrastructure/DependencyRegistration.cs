using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using PetConnect.Abstractions;
using PetConnect.Application.Features.Pets;
using PetConnect.Application.Features.Volunteers;
using PetConnect.Infrastructure.DbContexts;
using PetConnect.Infrastructure.Options;
using PetConnect.Infrastructure.Queries.Pets;
using PetConnect.Infrastructure.Repositories;
using PetConnect.Infrastructure.Tools;

namespace PetConnect.Infrastructure;

/// <summary>
/// Регистрация зависимостей слоя Infrastructure.
/// </summary>
public static class DependencyRegistration
{
    /// <summary>
    /// Регистрация зависимостей слоя Infrastructure.
    /// </summary>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddDataStorages(configuration)
            .AddRepositories()
            .AddQueries()
            .AddProviders()
            ;


    /// <summary>
    /// Регистрация хранилищ данных.
    /// </summary>
    public static IServiceCollection AddDataStorages(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddScoped<PetConnectReadDbContext>()
            .AddScoped<PetConnectWriteDbContext>()
            .AddMinio(configureClient: options =>
            {
                var minioOptions = configuration.GetSection(MinioOptions.Minio)
                    .Get<MinioOptions>() ?? throw new("Minio configuration not found");

                options.WithEndpoint(minioOptions.Endpoint);
                options.WithCredentials(minioOptions.AccessKey, minioOptions.SecretKey);
                options.WithSSL(false);
            })
            ;


    /// <summary>
    /// Регистрация реализаций репозиториев.
    /// </summary>
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
            .AddScoped<IPetsRepository, PetsRepository>()
            .AddScoped<IVolunteersRepository, VolunteerRepository>()
            ;


    /// <summary>
    /// Регистрация запросов на чтение.
    /// </summary>
    public static IServiceCollection AddQueries(this IServiceCollection services) =>
        services
            .AddScoped<GetPetsQuery>()
            ;


    /// <summary>
    /// Регистрация поставщиков сторонних сервисов.
    /// </summary>
    public static IServiceCollection AddProviders(this IServiceCollection services) =>
        services
            .AddScoped<IMinioProvider, MinioProvider>()
            ;
}
