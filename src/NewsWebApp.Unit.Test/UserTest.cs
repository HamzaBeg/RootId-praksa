using AutoMapper.QueryableExtensions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NewsWebApp.Buisness.Queries;
using NewsWebApp.ViewModels;
using System.Threading.Tasks;
using NewsWebApp.Buisness.Commands;
using NewsWebApp.Enumerations;
using NewsWebApp.Models;
using NewsWebApp.Unit.Test.Fixtures;
using Xunit;

namespace NewsWebApp.Unit.Test
{
    [Collection(nameof(SharedFixtureTest))]
    public class UserTest : IClassFixture<SharedFixtureTest>
    {
        private readonly SharedFixtureTest _fixture;

        public UserTest(SharedFixtureTest fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetUser_Should_Return_List_Of_UserViewModel()
        {
            var query = new GetAllUsers.Query();
            //Act

            var expectedResult = await _fixture.DbContext.User.AsNoTracking()
                .ProjectTo<LoginViewModel>(_fixture.Mapper.ConfigurationProvider)
                .ToListAsync();
            var result = await _fixture.Mediator.Send(query);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
        [Fact]
        public async Task AddUser_Should_Add_User()
        {
            string email = "esma.beganovic@gmail.com";
            string ime = "Esma";
            string prezime = "Beganovic";
            string password = "esma123";
           
            var command = new AddUser.CommandAdd(email,ime,prezime,password);
            //Act
            User user = await _fixture.DbContext.User.FirstOrDefaultAsync(u=>u.Email==email);
            //Assert
            user.Ime.Should().BeEquivalentTo(ime);
            user.Prezime.Should().BeEquivalentTo(prezime);
            user.Password.Should().BeEquivalentTo(password);
            user.Role.Should().Be(Role.User);
            user.IsActivate.Should().BeFalse();
            user.Status.Should().Be(Status.NotActive);

        }

        [Fact]
        public async Task Update_User_Status_Should_Update_Status_In_True()
        {
            int Id = 1;
            bool isActivate = true;

            var command = new EditUser.CommandEdit(Id,isActivate);
            //Act
            User user = await _fixture.DbContext.User.FirstOrDefaultAsync(u => u.Id == Id);
            //Assert
            user.IsActivate.Should().BeTrue();
        
        }

        [Fact]
        public async Task Delete_User_Should_Delete_User_And_Send_Message()
        {
            int id = 3;

            var command = new DeleteUser.CommandDelete(id);
            //Act
            User user = await _fixture.DbContext.User.FirstOrDefaultAsync(u => u.Id == id);
            //Assert
            user.Should().BeNull();
        }
    }
}
