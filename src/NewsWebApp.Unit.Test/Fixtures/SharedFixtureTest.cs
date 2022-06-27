using AutoMapper;
using MediatR;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsWebApp.Context;
using NewsWebApp.Repositories;
using NewsWebApp.Repositories.DefaultRepositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using NewsWebApp.Models;
using Xunit;

namespace NewsWebApp.Unit.Test.Fixtures
{
    public class SharedFixtureTest : IAsyncLifetime
    {
        public SharedFixtureTest()
        {
            Provider = ConfigureServiceProvider();
            Mediator = Provider.GetService<IMediator>();
            Mapper = Provider.GetService<IMapper>();
            DbContext = Provider.GetService<DbCoreContext>();

            DbContext?.Database.OpenConnection();
            DbContext?.Database.EnsureCreated();

            //AddSeedData();
        }

        public IServiceProvider Provider { get; }
        public IMediator Mediator { get; }
        public IMapper Mapper { get; }
        public DbCoreContext DbContext { get; }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        private static IServiceProvider ConfigureServiceProvider()
        {
            var assemblies = new[] {Assembly.GetAssembly(typeof(Startup))};

            var serviceCollection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

            serviceCollection.AddScoped<IAuthenticatiRepository, AuthenticatiRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddMediatR(assemblies);
            serviceCollection.AddAutoMapper(assemblies);

            var builder = new DbContextOptionsBuilder<DbCoreContext>();
            var connectionStringBuilder = new SqliteConnectionStringBuilder {DataSource = $"test.db"};
            var connectionString = connectionStringBuilder.ToString();

            builder.UseSqlite(connectionString);

            serviceCollection.AddScoped(provider => new DbCoreContext(builder.Options));

            var provider = serviceCollection.BuildServiceProvider();

            return provider;
        }

        private void AddSeedData()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "bradpit@s",
                    Password = "pit123",
                    Ime = "Brad",
                    Prezime = "Pit",
                },
                new User
                {
                    Id = 2,
                    Email = "hamzabeg@t",
                    Password = "hamza123",
                    Ime = "Hamza",
                    Prezime = "Beganovic",
                },
            };

            DbContext.User.AddRange(users);
            
            var news = new List<News>
            {
                new News
                {
                    Id = 1,
                    Title = "I am Hamza",
                    Description = "Student of Politehnicki fakultet in Zenica",
                    Content = "I learn .Net core",
                    UserId = 1
                },
                new News
                {
                    Id = 2,
                    Title = "I am junior developer",
                    Description = "With great story",
                    Content = "I will also try to learn Angular",
                    UserId = 1
                },
            };
            DbContext.News.AddRange(news);


            DbContext.SaveChanges();
        }
    }
}