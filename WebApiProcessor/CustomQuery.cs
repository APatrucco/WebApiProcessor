using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiProcessor
{
    public class CustomQuery
    { 
        public static void Query(List<Comment> comments)
        {
            try
            {
                Console.WriteLine("Please enter ID: ");
                int inputID = int.Parse(Console.ReadLine());

                var query = from Comment comment in comments
                            where comment.ID.Equals(inputID)
                            select comment.Body;

                foreach(var comment in query)
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
