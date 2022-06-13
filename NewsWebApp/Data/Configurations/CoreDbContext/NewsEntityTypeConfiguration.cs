using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebApp.Models;

namespace NewsWebApp.Data.Configurations.CoreDbContext
{
    public class NewsEntityTypeConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(x => x.NewId);

            builder.Property(x => x.NewId).IsRequired().ValueGeneratedOnAdd().UseIdentityColumn(); ;
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Date).HasDefaultValueSql("getdate()");
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

           

            builder.HasData(
                new News
                {
                    NewId = 1,
                    Title = "I am Hamza",
                    Description = "Student of Politehnicki fakultet in Zenica",
                    Content = "I learn .Net core",
                    UserId = 1
                },
                new News
                {
                    NewId = 2,
                    Title = "I am junior developer",
                    Description = "With great story",
                    Content = "I will also try to learn Angular",
                    UserId = 1
                });
        }
    }
}
