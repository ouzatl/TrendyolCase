using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trendyol.Utility.Helpers;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var webUrlResult = "";
            var deepLink = "ty://?Page=Search&Query=elbise";
            var url = new Uri(deepLink);
            const string searchBaseUrl = "https://www.trendyol.com/{0}";
            var parsedQuery = HttpUtility.ParseQueryString(url.Query);
            var queryType = parsedQuery.Get("Page");


            if (queryType.Equals("Search"))
            {
                var query = parsedQuery.Get("Query");
                if (!string.IsNullOrEmpty(query))
                    webUrlResult = string.Concat(string.Format(searchBaseUrl, "/tum--urunler?q="), query);
            }
            Console.WriteLine(webUrlResult);
        }
    }
}
