using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballSearch.Test
{
    public class MinimalDifferenceInGoalsTeamFinderTests
    {
        private readonly MinimalDifferenceInGoalsTeamFinder _finder;

        public MinimalDifferenceInGoalsTeamFinderTests()
        {
            _finder = new MinimalDifferenceInGoalsTeamFinder();
        }

        [Fact]
        public void EmptyEnumerableGiven_NullReturned()
        {
            Assert.Null(_finder.Find(Enumerable.Empty<FootballTeamData>()));
        }

        [Fact]
        public void ExaclyOneDayWithMinimumTemperatureSpread_Returned()
        {
            var days = new[]
            {
                new FootballTeamData("Byki", 1000, 1),
                new FootballTeamData("Janki",100,1),
                new FootballTeamData("Komtury",10000,1),
                new FootballTeamData("Bosy",10,1),
            };

            var result = _finder.Find(days);

            Assert.Equal("Bosy", result.Name);
        }

        [Fact]
        public void NullGiven_ArgumentExceptionThrown()
        {
            Assert.Throws<ArgumentNullException>(() => _finder.Find(null));
        }
    }
}