using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSearch
{
    public class SmallestTemperatureSpreadFinder
    {
        public DayTemperatureData Find(IEnumerable<DayTemperatureData> days)
        {
            return days.OrderBy(d => d.MaxTemperature - d.MinTemperature).FirstOrDefault();
        }
    }
}