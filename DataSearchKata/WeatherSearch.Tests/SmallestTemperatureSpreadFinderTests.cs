using System.Linq;
using Xunit;

namespace WeatherSearch.Tests
{
    public class SmallestTemperatureSpreadFinderTests
    {
        private readonly SmallestTemperatureSpreadFinder _finder;

        public SmallestTemperatureSpreadFinderTests()
        {
            _finder = new SmallestTemperatureSpreadFinder();
        }

        [Fact]
        public void EmptyEnumerableGiven_NullReturned()
        {
            Assert.Null(_finder.Find(Enumerable.Empty<DayTemperatureData>()));
        }

        [Fact]
        public void ExaclyOneDayWithMinimumTemperatureSpread_Returned()
        {
            var days = new[]
            {
                new DayTemperatureData(1,100,1),
                new DayTemperatureData(2,1000,1),
                new DayTemperatureData(3,10000,1),
                new DayTemperatureData(4,10,1),
            };

            var result = _finder.Find(days);

            Assert.Equal(4, result.DayNo);
        }
    }
}