using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetConnect.Domain.Entities;
using PetConnect.Infrastructure.Conventions;

namespace PetConnect.Infrastructure;

/// <summary>
/// Контекст базы данных для проекта PetConnect.
/// </summary>
public class PetConnectDbContext(IConfiguration configuration) : DbContext
{
    /// <summary>
    /// Конфигурация системы развёртывания.
    /// </summary>
    private readonly IConfiguration _configuration = configuration;


    /// <summary>
    /// Таблица с животными.
    /// </summary>
    public DbSet<Pet> Pets => Set<Pet>();

    

    /// <summary>
    /// Конфигурация работы контекста данных.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString(nameof(PetConnectDbContext)));
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    /// <summary>
    /// Конфигурация соглашений.
    /// </summary>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        // Соглашение о хранении DateTimeOffset в базе данных только с нулевым смещением (хранение времени только по Гринвичу).
        configurationBuilder.Properties<DateTimeOffset>().HaveConversion<DateTimeOffsetConverter>();
    }

    /// <summary>
    /// Конфигурация сущностей контекста данных.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetConnectDbContext).Assembly);
    }
}
