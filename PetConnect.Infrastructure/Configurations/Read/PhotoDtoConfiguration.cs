using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetConnect.Application.Dtos;

namespace PetConnect.Infrastructure.Configurations.Read;

/// <summary>
/// Конфигурация фотографии на чтение.
/// </summary>
public class PhotoDtoConfiguration : IEntityTypeConfiguration<PhotoDto>
{
    public void Configure(EntityTypeBuilder<PhotoDto> builder)
    {
        builder.ToTable("photos");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.OwnerId).HasColumnName("pet_id");
    }
}
