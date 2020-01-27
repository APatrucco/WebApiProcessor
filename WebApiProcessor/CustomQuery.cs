using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiProcessor
{
    public class CustomQuery
    {
        public static IEnumerable<dynamic> Query(IEnumerable<dynamic> someList)
        {
            Console.WriteLine("Please enter user ID: ");
            int inputID = int.Parse(Console.ReadLine());

            dynamic query = from dynamic item in someList
                            where item.ID.Equals(inputID)
                            select item;

            return query;
        }
    }
}
