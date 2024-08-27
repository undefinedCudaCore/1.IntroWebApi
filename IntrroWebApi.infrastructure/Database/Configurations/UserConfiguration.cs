using IntroWepApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroWebApi.Infrastructure.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            //PK
            builder.HasKey(u => u.Id);

            //Since using GUID we want to generate ID inside out application
            builder.Property(u => u.Id)
                .IsRequired()
            .ValueGeneratedNever();

            builder.Property(u => u.UserName)
                .IsRequired()
            .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.City)
                .HasMaxLength(100);

            builder.Property(u => u.FileName)
                .HasMaxLength(255);

            builder.Property(u => u.FileData)
                .HasColumnType("varbinary(max)");

            // Index
            builder.HasIndex(u => u.UserName)
            .IsUnique();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            //Seed data
            builder.HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "JohnDoe",
                    Email = "johndoe@example.com",
                    City = "New York"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "JohnNotDoe",
                    Email = "johnnotdoe@notexample.notcom",
                    City = "Los Angeles"
                }
            );
        }
    }
}
