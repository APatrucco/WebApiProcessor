using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace WebApiProcessor
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {
            try
            {
                string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/comments");

                JArray commentArray = JsonConvert.DeserializeObject<dynamic>(response);

                List<Comment> comments = new List<Comment>();

                foreach(var comment in commentArray)
                {
                    try
                    {
                        Comment newComment = new Comment();
                        
                        JsonConvert.PopulateObject(comment.ToString(), newComment);

                        comments.Add(newComment);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Exception Caught!\n{ex.Message}");
                    }
                }

                // Test Query
                CustomQuery.Query(comments);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Exception Caught!\nMessage : {ex.Message}");
            }
        }
    }
}
