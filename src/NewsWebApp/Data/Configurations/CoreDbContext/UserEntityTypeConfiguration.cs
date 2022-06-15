using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebApp.Enumerations;
using NewsWebApp.Models;

namespace NewsWebApp.Data.Configurations.CoreDbContext
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasMany(e => e.News)
                .WithOne(e => e.User);

            builder.Property(x => x.UserId).IsRequired().ValueGeneratedOnAdd().UseIdentityColumn(); ;
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Ime).IsRequired();
            builder.Property(x => x.Prezime).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Role).IsRequired().HasDefaultValue(Role.User);
            builder.Property(x => x.Status).HasDefaultValue(Status.NotActive);
            builder.Property(x => x.IsActivate).HasDefaultValue(false);

            builder.HasData(
                new User
                {
                    UserId = 1,
                    Email = "bradpit@s",
                    Password = "pit123",
                    Ime = "Brad",
                    Prezime = "Pit",
                },
                new User
                {
                    UserId = 2,
                    Email = "hamzabeg@t",
                    Password = "hamza123",
                    Ime = "Hamza",
                    Prezime = "Beganovic",
                });
        }
    }
}
