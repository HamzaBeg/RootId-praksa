﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsWebApp.Enumerations;

namespace NewsWebApp.Context
{
    public static class DbNovostiContextExstensions
    {
        public static IServiceCollection AddCoreDbContext(this IServiceCollection service, IConfiguration configuration)
        {
            return service.AddScoped(provider => Build(provider, configuration));
        }

        private static DbCoreContext Build(IServiceProvider provider, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("CoreDb");

            var builder = new DbContextOptionsBuilder<DbCoreContext>().UseSqlServer(connectionString);
            return new DbCoreContext(builder.Options);
        }

        public static IApplicationBuilder UseCoreDbContext(this IApplicationBuilder applicationBuilder)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope();

            try
            {
                using var context = scope.ServiceProvider.GetService<DbCoreContext>();
                var listUsers=context.User.Where(x => x.IsActivate == true).ToList();

                foreach (var user in listUsers)
                {
                    user.IsActivate = false;
                    user.Status = Status.NotActive;
                    context.Update(user);
                }
                context.SaveChanges();
                context.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return applicationBuilder;
        }
    }
}
