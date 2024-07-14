using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetConnect.Domain.Entities;

namespace PetConnect.Infrastructure;

/// <summary>
/// Контекст базы данных для PetFamily.
/// </summary>
public class PetConnectDbContext : DbContext
{
    /// <summary>
    /// 
    /// </summary>
    private readonly IConfiguration _configuration;

    public PetConnectDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Pet> Pets => Set<Pet>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString(nameof(PetConnectDbContext)));
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetConnectDbContext).Assembly);
    }

}
