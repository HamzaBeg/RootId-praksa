using AutoMapper.QueryableExtensions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NewsWebApp.Buisness.Queries;
using NewsWebApp.ViewModels;
using System.Threading.Tasks;
using NewsWebApp.Buisness.Commands;
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

            var expectedGameStatusForPlayer = await _fixture.DbContext.User.AsNoTracking()
                .ProjectTo<LoginViewModel>(_fixture.Mapper.ConfigurationProvider)
                .ToListAsync();
            var result = await _fixture.Mediator.Send(query);

            //Assert
            result.Should().BeEquivalentTo(expectedGameStatusForPlayer);
        }
        [Fact]
        public async Task AddUser_Should_Add_User_And_Send_Message()
        {
            string email = "esma.beganovic@gmail.com";
            string ime = "Esma";
            string prezime = "Beganovic";
            string password = "esma123";
           
            var command = new AddUser.CommandAdd(email,ime,prezime,password);
            //Act
            var expectedResult1 = "You have successfully added user!";
            var expectedResult2 = "User already exist!";
            var result = await _fixture.Mediator.Send(command);
            //Assert
            if(result == expectedResult1)
            {
                result.Should().BeEquivalentTo(expectedResult1);
            }
            result.Should().BeEquivalentTo(expectedResult2);
        }

        [Fact]
        public async Task Update_Game_Status_Should_Update_Or_Return_Message()
        {
            int Id = 1;
            bool isActivate = true;

            var command = new EditUser.CommandEdit(Id,isActivate);
            //Act
            var expectedResult1 = "You have successfully updated user!";
            var expectedResult2 = "User already exist!";
            var result = await _fixture.Mediator.Send(command);
            //Assert
            if (result == expectedResult1)
            {
                result.Should().BeEquivalentTo(expectedResult1);
            }
            else
            result.Should().BeEquivalentTo(expectedResult2);
        }
    }
}
