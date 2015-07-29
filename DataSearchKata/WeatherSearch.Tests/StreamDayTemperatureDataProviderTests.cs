using System.CodeDom;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace WeatherSearch.Tests
{
    public class StreamDayTemperatureDataProviderTests
    {
        private FileDayTemperatureDataProvider _provider = new FileDayTemperatureDataProvider();

        [Fact]
        public void EmptyStream_ReturnsEmptyEnumerable()
        {
            using (var stream = CreateStringStream(""))
            {
                var result = _provider.ReadData(stream);
                Assert.Equal(0, result.Count());
            }
        }

        [Theory]
        [InlineData("asdasd sad as das")]
        [InlineData("12 32 dasdasd ")]
        public void WrongFormatString_ReturnsEmptyEnumerable(string wrongFormatString)
        {
            using (var stream = CreateStringStream(wrongFormatString))
            {
                var result = _provider.ReadData(stream);
                Assert.Equal(0, result.Count());
            }
        }

        [Theory]
        [InlineData("12 100 1")]
        [InlineData("   12 32 21")]
        [InlineData("12312 22 11 dasd sd ad a")]
        public void ProperFormatString_ParsesData(string properFormatString)
        {
            using (var stream = CreateStringStream(properFormatString))
            {
                var result = _provider.ReadData(stream).ToArray();
                Assert.Equal(1, result.Length);
            }
        }

        [Fact]
        public void MultilineInput_Parses()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("12 100 1");
            stringBuilder.AppendLine("asd sdas s");
            stringBuilder.AppendLine("11 32 1");

            using (var stream = CreateStringStream(stringBuilder.ToString()))
            {
                var result = _provider.ReadData(stream).ToArray();
                Assert.Equal(2, result.Length);
                Assert.True((new[] { 12, 11 }).SequenceEqual(result.Select(d => d.DayNo)));
            }
        }

        private static Stream CreateStringStream(string stringData)
        {
            var memStream = new MemoryStream();
            var streamWriter = new StreamWriter(memStream);
            streamWriter.Write(stringData);
            streamWriter.Flush();
            memStream.Seek(0, SeekOrigin.Begin);
            return memStream;
        }
    }
}