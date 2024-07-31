using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetConnect.Domain.Entities;
using PetConnect.Domain.ValueObjects;
using System.Text.Json;

namespace PetConnect.Infrastructure.Configurations.Write;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.YearsExperience).IsRequired();
        builder.Property(e => e.FromShelter).IsRequired();


        builder.Property(p => p.SocialMedias).HasConversion(
            socialMedia => JsonSerializer.Serialize(socialMedia, JsonSerializerOptions.Default),
            socialMediaString => JsonSerializer.Deserialize<SocialMedias>(socialMediaString, JsonSerializerOptions.Default)!);

        builder
            .HasMany(e => e.Photos)
            .WithOne();

        builder
            .HasMany(e => e.Pets)
            .WithOne();
    }
}