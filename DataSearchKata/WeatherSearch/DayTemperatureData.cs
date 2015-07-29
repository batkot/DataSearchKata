using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherSearch
{
    public class DayTemperatureData
    {
        public DayTemperatureData(int dayNo, int maxTemperature, int minTemperature)
        {
            DayNo = dayNo;
            MaxTemperature = maxTemperature;
            MinTemperature = minTemperature;
        }

        public int DayNo { get; private set; }

        public int MaxTemperature { get; private set; }

        public int MinTemperature { get; private set; }
    }
}