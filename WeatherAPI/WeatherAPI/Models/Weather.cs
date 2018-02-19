using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace WeatherAPI.Models
{
    public class Weather
    {
        [Required]
        public String City { get; set; }

        [Range(-50, 50)]
        public Double Temperature { get; set; }

        [Range(0, 200)]
        public Double WindSpeed { get; set; }

        public String Conditions { get; set; }

        public bool WeatherWarning { get; set; }

    }
}