using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiProcessor
{

    public class CustomQuery
    {
        public static void QueryUsers(List<User> users)
        {
            try
            {
                Console.WriteLine("Please enter ID: ");
                int inputID = int.Parse(Console.ReadLine());

                var queryName = from User user in users
                                where user.ID.Equals(inputID)
                                select user;

                foreach (var user in queryName)
                    Console.WriteLine($"Name: {user.Name}\nUsername: {user.UserName}\nAddress:\nStreet: {user.Address.Street}\n" +
                        $"Suite: {user.Address.Suite}\nCity: {user.Address.City}\nZip: {user.Address.ZipCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void QueryPosts(List<Post> posts)
        {
            try
            {
                Console.WriteLine("Please enter ID: ");
                int inputID = int.Parse(Console.ReadLine());

                var queryPost = from Post post in posts
                                where post.ID.Equals(inputID)
                                select post;

                foreach (var post in queryPost)
                    Console.WriteLine($"Title: {post.Title}\n Post: {post.Body}\n");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void QueryComments(List<Comment> comments)
        {
            try
            {
                Console.WriteLine("Please enter ID: ");
                int inputID = int.Parse(Console.ReadLine());

                var queryComment = from Comment comment in comments
                            where comment.ID.Equals(inputID)
                            select comment.Body;

                foreach(var comment in queryComment)
                {
                    Console.WriteLine(comment);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
