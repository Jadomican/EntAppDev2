using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [RoutePrefix("weather")]
    public class WeatherController : ApiController
    {

        private static List<Weather> weather = new List<Weather>()
        {
            new Weather { City = "Dublin", Conditions = "Sunny", WeatherWarning = false, WindSpeed = 30, Temperature = 17 },
            new Weather { City = "Celbridge", Conditions = "Hurricane", WeatherWarning = true, WindSpeed = 80, Temperature = 5 },
            new Weather { City = "Wicklow", Conditions = "Cloudy", WeatherWarning = false, WindSpeed = 25, Temperature = 12 },
            new Weather { City = "Cork", Conditions = "Sunny", WeatherWarning = false, WindSpeed = 40, Temperature = 8 }
        };

        // GET /weather/all
        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetAllWeatherInfo()
        {
            return Ok(weather.OrderBy(w => w.City).ToList());
        }


        // GET /weather/city/Dublin
        [Route("city/{cityName:alpha}")]
        public IHttpActionResult GetWeatherInfoForCity(String cityName)
        {
            Weather cityWeather = weather.FirstOrDefault(w => w.City.ToUpper() == cityName.ToUpper());
            if (cityName == null)
            {
                return NotFound();
            }
            return Ok(cityWeather);
        }


        // GET /weather/cities/warning/{warning:bool}
        [Route("cities/warning/{warning:bool}")]
        public IEnumerable<String> GetCitiesForWarningStatus(bool warning)
        {
            //LINQ
            var cities = weather.Where(w => w.WeatherWarning == warning).Select(w => w.City);
            return cities;
        }

    }
}
