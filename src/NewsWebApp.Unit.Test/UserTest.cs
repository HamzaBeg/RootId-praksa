using AutoMapper.QueryableExtensions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NewsWebApp.Buisness.Queries;
using NewsWebApp.ViewModels;
using System.Threading.Tasks;
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
    }
}
