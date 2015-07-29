using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSearch
{
    public class MinimalDifferenceInGoalsTeamFinder
    {
        public FootballTeamData Find(IEnumerable<FootballTeamData> teams)
        {
            return teams.OrderBy(team => Math.Abs(team.ScoredGoals - team.LostGoals)).FirstOrDefault();
        }
    }
}