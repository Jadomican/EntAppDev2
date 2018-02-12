using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RestfulLabSMSClient
{
    class Client
    {

        static async Task RunAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:32714");

                    //accept header
                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //POST /api/SMSService with a text message serialised in request body
                    //send a txt msg

                    TextMessage txt = new TextMessage() {
                        SourceNumber = "0851068162",
                        Content = "Hello :D",
                        DestinationNumber = "0834573234"
                    };

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/SMSService", txt);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Message sent ok");
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

        static void Main(string[] args)
        {
            Task result = RunAsync();
            result.Wait();
            Console.ReadLine();
        }
    }
}
