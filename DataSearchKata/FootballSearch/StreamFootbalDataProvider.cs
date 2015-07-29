using SearchCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballSearch
{
    public class StreamFootbalDataProvider : StreamDataReader<FootballTeamData>
    {
        protected override string LineMatchPattern
        {
            get { return @"^\s*\d+\.\s+([^\s]+).+\s+(\d+)\s+\-\s+(\d+)"; }
        }

        protected override FootballTeamData ParseRegexResult(Match regexMatch)
        {
            return new FootballTeamData(regexMatch.Groups[1].Value,
                                        int.Parse(regexMatch.Groups[2].Value),
                                        int.Parse(regexMatch.Groups[3].Value)); ;
        }
    }
}