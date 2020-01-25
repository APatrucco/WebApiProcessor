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
                // Fetch JSON from API
                string fetchedComments = await client.GetStringAsync("https://jsonplaceholder.typicode.com/comments");
                string fetchedPosts = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
                string fetchedUsers = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

                // Deserializes JSON into JArray
                JArray commentArray = JsonConvert.DeserializeObject<dynamic>(fetchedComments);
                JArray postArray = JsonConvert.DeserializeObject<dynamic>(fetchedPosts);
                JArray userArray = JsonConvert.DeserializeObject<dynamic>(fetchedUsers);

                List<Comment> comments = new List<Comment>();
                List<Post> posts = new List<Post>();
                List<User> users = new List<User>();

                Console.WriteLine("What would you like to query?\n1. Users\n2. Posts\n3. Comments");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        foreach(var user in userArray)
                        {
                            User newUser = new User();

                            JsonConvert.PopulateObject(user.ToString(), newUser);

                            users.Add(newUser);
                        }

                        CustomQuery.QueryUsers(users);
                        break;

                    case 2:
                        foreach(var post in postArray)
                        {
                            Post newPost = new Post();

                            JsonConvert.PopulateObject(post.ToString(), newPost);

                            posts.Add(newPost);
                        }

                        CustomQuery.QueryPosts(posts);
                        break;

                    case 3:
                        foreach(var comment in commentArray)
                        {
                            Comment newComment = new Comment();

                            JsonConvert.PopulateObject(comment.ToString(), newComment);

                            comments.Add(newComment);

                        }
                        
                        CustomQuery.QueryComments(comments);
                        break;

                    default:
                        Console.WriteLine("Please enter a valid entry.");
                        break;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Exception Caught!\n{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Caught!\n{ex.Message}");
            }
        }
    }
}
