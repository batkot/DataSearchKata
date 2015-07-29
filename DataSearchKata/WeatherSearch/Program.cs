using System;
using System.IO;

namespace WeatherSearch
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
                var dataProvider = new FileDayTemperatureDataProvider();
                var solutionFinder = new SmallestTemperatureSpreadFinder();

                var result = solutionFinder.Find(dataProvider.ReadData(fileStream));

                if (result == null)
                {
                    Console.Write(ResultNotFoundMessage);
                }
                else
                {
                    Console.WriteLine(string.Format("Result! Day: {0}, Max T: {1}, Min T: {2}", result.DayNo, result.MaxTemperature, result.MinTemperature));
                }
            }

            Console.ReadKey();
        }

        private const string HelpMessage = "No given arguments. Please set file location";
        private const string FileNotFound = "File {0} not found!";
        private const string ResultNotFoundMessage = "No result found!";
    }
}