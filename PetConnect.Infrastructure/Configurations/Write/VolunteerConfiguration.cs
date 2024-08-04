using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetConnect.Domain.Common;
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

        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(Constraints.SHORT_TITLE_LENGTH);

        builder.Property(v => v.Description)
            .IsRequired()
            .HasMaxLength(Constraints.LONG_TITLE_LENGTH);

        builder.Property(v => v.YearsExperience)
            .IsRequired();

        builder.Property(v => v.SuccessFoundHomeForPetCount)
            .IsRequired(false);

        builder.Property(v => v.DonationInfo)
            .IsRequired(false)
            .HasMaxLength(Constraints.LONG_TITLE_LENGTH);

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