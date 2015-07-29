using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherSearch
{
    public class FileDayTemperatureDataProvider
    {
        public IEnumerable<DayTemperatureData> ReadData(Stream dataStream)
        {
            using (var reader = new StreamReader(dataStream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var matchResult = _dataMatchRegex.Match(line);

                    if (matchResult.Success)
                    {
                        yield return new DayTemperatureData(
                            int.Parse(matchResult.Groups[1].Value),
                            int.Parse(matchResult.Groups[2].Value),
                            int.Parse(matchResult.Groups[3].Value));
                    }
                }
            }
        }

        private readonly Regex _dataMatchRegex = new Regex(@"^\s*(\d+)\s+(\d+)\s+(\d+)");
    }
}