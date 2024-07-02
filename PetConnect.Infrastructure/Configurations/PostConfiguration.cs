using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetConnect.Domain;

namespace PetConnect.Infrastructure.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Breed).IsRequired();
        builder.Property(p => p.Height).IsRequired().HasMaxLength(1000);

        builder.ComplexProperty(p => p.MainPhoto, b =>
        {
            b.Property(m => m.PhotoPath).IsRequired().HasColumnName("photo_path");
        });

        builder.HasMany(p => p.Photos).WithOne() ;  
    }
}
