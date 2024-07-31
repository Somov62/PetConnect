using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetConnect.Application.Dtos;

namespace PetConnect.Infrastructure.Configurations.Read;

/// <summary>
/// Конфигурация таблицы с животными на чтение.
/// </summary>
public class PetDtoConfiguration : IEntityTypeConfiguration<PetDto>
{
    public void Configure(EntityTypeBuilder<PetDto> builder)
    {
        builder.ToTable("pets");
        builder.HasKey(p => p.Id);

        builder
            .HasMany(p => p.Photos)
            .WithOne()
            .HasForeignKey(ph => ph.OwnerId);

        builder.Navigation(p => p.Photos).AutoInclude();
    }
}
