using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProductsListAPIClient
{
    class Client
    {

        static async Task RunAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:21614");

                    //accept header
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/Products/");

                    if (response.IsSuccessStatusCode)
                    {
                        //parse result
                        Product[] products = response.Content.ReadAsAsync<Product[]>().Result;
                        foreach (var p in products)
                        {
                            Console.WriteLine("{0}, {1}, {2}, ${3}", p.Id, p.Name, p.Category, p.Price);
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

        static async Task AddAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:21614/");

                    //accept header
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    Product newProduct = new Product() { Id = 5, Name = "Nissan Micra", Category = "Car", Price = 3000 };
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/products", newProduct);
                    if (response.IsSuccessStatusCode)
                    {
                        Uri newProductURI = response.Headers.Location;
                        var product = await response.Content.ReadAsAsync<Product>();
                        Console.WriteLine("URI for new resource: " + newProductURI.ToString());
                        Console.WriteLine("resource " + product.Name + " " + product.Price);
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

        static void Main()
        {
            //Task result = RunAsync();               // convention is for async methods to finish in Async
            //result.Wait();                          // block, not the same as await        

            Task result = AddAsync();
            result.Wait();

            Console.ReadKey();
        }
    }
}
