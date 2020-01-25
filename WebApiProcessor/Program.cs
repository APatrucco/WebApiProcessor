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

                Console.WriteLine("What would you like to query?\n   1. Users\n   2. Posts\n   3. Comments");
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

                        var query = CustomQuery.Query(users);

                        foreach (var user in query)
                            Console.WriteLine($"Name: {user.Name}\nUsername: {user.UserName}\nAddress:\nStreet: {user.Address.Street}\n" +
                                $"Suite: {user.Address.Suite}\nCity: {user.Address.City}\nZip: {user.Address.ZipCode}");

                        break;

                    case 2:
                        foreach(var post in postArray)
                        {
                            Post newPost = new Post();

                            JsonConvert.PopulateObject(post.ToString(), newPost);

                            posts.Add(newPost);
                        }

                        query = CustomQuery.Query(posts);

                        foreach (var post in query)
                            Console.WriteLine($"Title: {post.Title}\nPost: {post.Body}\n");

                        break;

                    case 3:
                        foreach(var comment in commentArray)
                        {
                            Comment newComment = new Comment();

                            JsonConvert.PopulateObject(comment.ToString(), newComment);

                            comments.Add(newComment);

                        }
                        
                        query = CustomQuery.Query(comments);

                        foreach (var comment in query)
                            Console.WriteLine($"\nName: {comment.Name}\nEmail: {comment.Email}\nComment: {comment.Body}");

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
