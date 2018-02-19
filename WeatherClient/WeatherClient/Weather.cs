using System;

namespace WeatherClient
{
    public class Weather
    {
        public String City { get; set; }
        public Double Temperature { get; set; }
        public Double WindSpeed { get; set; }
        public String Conditions { get; set; }
        public bool WeatherWarning { get; set; }
    }
}