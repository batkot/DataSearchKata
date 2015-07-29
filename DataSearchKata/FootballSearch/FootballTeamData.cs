using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballSearch
{
    public class FootballTeamData
    {
        public FootballTeamData(string name, int scoredGoals, int lostGoals)
        {
            ScoredGoals = scoredGoals;
            LostGoals = lostGoals;
            Name = name;
        }

        public string Name { get; private set; }

        public int LostGoals { get; private set; }

        public int ScoredGoals { get; private set; }
    }
}