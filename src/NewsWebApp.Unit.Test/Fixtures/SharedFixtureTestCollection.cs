using NewsWebApp.Unit.Test.Fixtures;
using Xunit;

namespace NewsWebApp.Unit.Test
{
    [CollectionDefinition(nameof(SharedFixtureTest))]
    public class SharedFixtureTestCollection : ICollectionFixture<SharedFixtureTest>
    {
    }
}