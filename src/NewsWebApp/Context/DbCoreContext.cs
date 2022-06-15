using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsWebApp.Data.Configurations.CoreDbContext;
using NewsWebApp.Models;

namespace NewsWebApp.Context
{
    public class DbCoreContext : DbContext
    {
        public DbCoreContext(DbContextOptions<DbCoreContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new NewsEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);

        }
    }
}
