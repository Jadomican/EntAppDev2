using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using WeatherClient;

namespace WeatherClient
{
    class Client
    {
        //async call
        static async Task DoWork()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:27779");

                    //add an Accept header for JSON
                    client.DefaultRequestHeaders.Accept.
                        Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //1
                    //weather info for all cities
                    HttpResponseMessage response = await client.GetAsync("weather/all");
                    if (response.IsSuccessStatusCode)
                    {
                        //read result
                        Console.WriteLine("All cities:\n");
                        var weather = await response.Content.ReadAsAsync<IEnumerable<Weather>>();
                        foreach (var w in weather)
                        {
                            Console.WriteLine("{0}, {1}, {2}C, warning: {3}, {4}", w.City, w.Conditions, w.Temperature, w.WeatherWarning, w.WindSpeed);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }


                    //2
                    //weather info for specific city
                    Weather weatherInfo = new Weather();

                    String cityChoice;
                    Console.WriteLine("\nEnter a city: ");
                    cityChoice = Console.ReadLine();

                    response = await client.GetAsync("weather/city/" + cityChoice);
                    if (response.IsSuccessStatusCode)
                    {
                        //read result
                        weatherInfo = await response.Content.ReadAsAsync<Weather>();
                        Console.WriteLine("{0}, {1}, {2}C, warning: {3}, {4}",
                            weatherInfo.City, weatherInfo.Conditions, weatherInfo.Temperature, 
                            weatherInfo.WeatherWarning, weatherInfo.WindSpeed);
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }


                    //3
                    //get cities with warning in place
                    Console.WriteLine("\nCities with a warning:");

                    response = client.GetAsync("weather/cities/warning/true").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        //read result
                        var cities = await response.Content.ReadAsAsync<IEnumerable<String>>();
                        foreach (String city in cities)
                        {
                            Console.WriteLine(city);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        // kick off
        static void Main()
        {
            DoWork().Wait();
            Console.ReadKey();
        }
    }



}
