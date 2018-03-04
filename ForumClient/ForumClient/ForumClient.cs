using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ForumClient
{
    class ForumClient
    {

        static async Task GetAllPostsAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:29899");

                    //accept header
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("forum/all");

                    if (response.IsSuccessStatusCode)
                    {
                        //parse result
                        Post[] posts = response.Content.ReadAsAsync<Post[]>().Result;
                        Console.WriteLine("\nList of posts:\n");
                        foreach (var p in posts)
                        {
                            Console.WriteLine("{0}\n {1}\n {2}\n {3},\n", p.Id, p.Subject, p.Message, p.TimeStamp);
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

        static async Task GetLastPostsAsync(int numberPosts)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:29899");

                    //accept header
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("forum/last/" + numberPosts);

                    if (response.IsSuccessStatusCode)
                    {
                        //parse result
                        Post[] posts = response.Content.ReadAsAsync<Post[]>().Result;
                        Console.WriteLine("\nLast " + numberPosts + " posts:\n");
                        foreach (var p in posts)
                        {
                            Console.WriteLine("{0}\n {1}\n {2}\n {3},\n", p.Id, p.Subject, p.Message, p.TimeStamp);
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


        static async Task AddPostAsync(String subject, String message)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:29899");

                    //accept header
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Post newPost = new Post() { Subject = subject , Message = message};
                    HttpResponseMessage response = await client.PostAsJsonAsync("forum", newPost);
                    if (response.IsSuccessStatusCode)
                    {
                        Uri newPostUri = response.Headers.Location;
                        var post = await response.Content.ReadAsAsync<Post>();
                        Console.WriteLine("URI for new resource: " + newPostUri.ToString());
                        Console.WriteLine("resource " + post.Id + " " + post.Subject);
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


        static async Task UpdatePostAsync(int id, String subject, String message)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:29899");

                    
                    Post newPost = new Post() { Id = id, Subject = subject, Message = message };
                    HttpResponseMessage response = await client.PutAsJsonAsync("forum", newPost);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("\nUpdated post " + id + "\n");
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
            Task resultPost = AddPostAsync("First Post", "HELLO this is my first post");
            resultPost.Wait();

            Task resultPost2 = AddPostAsync("Second Post", "HELLO this is my second post");
            resultPost2.Wait();

            Task resultGet = GetAllPostsAsync();
            resultGet.Wait();

            Task resultUpdate = UpdatePostAsync(2, "Update", "This was an update");
            resultUpdate.Wait();

            Task resultGetAfterUpdate = GetAllPostsAsync();
            resultGetAfterUpdate.Wait();


            Task resultGetLastPosts = GetLastPostsAsync(3);
            resultGetLastPosts.Wait();

            Console.ReadKey();
        }
    }
}
