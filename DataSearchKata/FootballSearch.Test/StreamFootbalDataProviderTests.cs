using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace FootballSearch.Test
{
    public class StreamFootbalDataProviderTests
    {
        private readonly StreamFootbalDataProvider _provider = new StreamFootbalDataProvider();

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
        [InlineData("    1. Arsenal         38    26   9   3    79  -  36    87")]
        [InlineData("    8. Aston_Villa     38    12  14  12    46  -  47    5")]
        [InlineData("5. Leeds           38    18  12   8    53  -  37    66")]
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
            stringBuilder.AppendLine("    1. Arsenal         38    26   9   3    79  -  36    87");
            stringBuilder.AppendLine("    8. Aston_Villa     38    12  14  12    46  -  47    5");
            stringBuilder.AppendLine("   ------------------------------------------------------");

            using (var stream = CreateStringStream(stringBuilder.ToString()))
            {
                var result = _provider.ReadData(stream).ToArray();
                Assert.Equal(2, result.Length);
                Assert.True((new int[] { 79, 46 }).SequenceEqual(result.Select(team => team.ScoredGoals)));
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