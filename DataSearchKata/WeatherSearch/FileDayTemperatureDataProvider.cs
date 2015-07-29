using SearchCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherSearch
{
    public class FileDayTemperatureDataProvider : StreamDataReader<DayTemperatureData>
    {
        protected override string LineMatchPattern
        {
            get { return @"^\s*(\d+)\s+(\d+)\s+(\d+)"; }
        }

        protected override DayTemperatureData ParseRegexResult(Match regexMatch)
        {
            return new DayTemperatureData(
                            int.Parse(regexMatch.Groups[1].Value),
                            int.Parse(regexMatch.Groups[2].Value),
                            int.Parse(regexMatch.Groups[3].Value)); ;
        }
    }
}