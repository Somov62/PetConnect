using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetConnect.Domain.Entities;

namespace PetConnect.Infrastructure.Configurations.Write;
public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.ToTable("photos");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Path).IsRequired();
        builder.Property(p => p.IsMain).IsRequired();
    }
}