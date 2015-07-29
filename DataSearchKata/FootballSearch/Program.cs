using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSearch
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine(HelpMessage);
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.Write(string.Format(FileNotFound, args[0]));
                return;
            }

            using (var fileStream = File.OpenRead(args[0]))
            {
                var dataProvider = new StreamFootbalDataProvider();
                var solutionFinder = new MinimalDifferenceInGoalsTeamFinder();

                var result = solutionFinder.Find(dataProvider.ReadData(fileStream));

                if (result == null)
                {
                    Console.Write(ResultNotFoundMessage);
                }
                else
                {
                    Console.WriteLine(string.Format("Result! Team Name: {0}, Scored Goals: {1}, Lost Goals: {2}", result.Name, result.ScoredGoals, result.LostGoals));
                }
            }

            Console.ReadKey();
        }

        private const string HelpMessage = "No given arguments. Please set file location";
        private const string FileNotFound = "File {0} not found!";
        private const string ResultNotFoundMessage = "No result found!";
    }
}