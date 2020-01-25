using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiProcessor
{

    public class CustomQuery
    {
        public static IEnumerable<dynamic> Query(IEnumerable<dynamic> someList)
        {
            Console.WriteLine("Please enter ID: ");
            int inputID = int.Parse(Console.ReadLine());

            var query = from dynamic item in someList
                            where item.ID.Equals(inputID)
                            select item;

            return query;
        }
    }
}
