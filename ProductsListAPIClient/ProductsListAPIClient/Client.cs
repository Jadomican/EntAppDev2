using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProductsListAPIClient
{
    class Client
    {

        //GET - retrieve all products
        static async Task GetAllProductsAsync()
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
                        Console.WriteLine("\nList of Products:");
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

        //POST - add new product
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


        //PUT update
        static async Task UpdateAsync(int idChoice)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:21614/");
                    
                    Product product = new Product() {Id = idChoice, Name = "Teabags", Category = "Drink", Price = 2 };

                    HttpResponseMessage response = await client.PutAsJsonAsync("api/products/" + idChoice.ToString(), product);
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //DELETE
        static async Task DeleteAsync(int idChoice)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:21614/");

                    HttpResponseMessage response = await client.DeleteAsync("api/products/" + idChoice.ToString());
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
 
        static void Main()
        {
            Task resultGet = GetAllProductsAsync();         // convention is for async methods to finish in Async
            resultGet.Wait();                               // block, not the same as await        

            //Task resultPost = AddAsync();
            //resultPost.Wait();

            Console.WriteLine("Enter the id to be updated:");
            int idChoice = Convert.ToInt32(Console.ReadLine());
            Task resultPut = UpdateAsync(idChoice);
            resultPut.Wait();

            Task resultGetAfterPut = GetAllProductsAsync();
            resultGetAfterPut.Wait();

            Console.WriteLine("\nEnter the id to be DELETED:");
            idChoice = Convert.ToInt32(Console.ReadLine());
            Task resultDelete = DeleteAsync(idChoice);
            resultDelete.Wait();

            Task resultGetAfterDelete = GetAllProductsAsync();
            resultGetAfterDelete.Wait();

            Console.ReadKey();
        }
    }
}
