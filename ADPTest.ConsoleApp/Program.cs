using System;
using System.Net.Http;
using System.Threading;

namespace ADPTest.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Timer adpTimer = new Timer(CallApi, null, 0, 50000);
                      
            Console.ReadLine();
        }

        private async static void CallApi(Object source)
        {
            using(var client = new HttpClient())
            {
                // Because it's small test/simulation, the URL is fixed here instead in appSettings
                var url = @"https://localhost:7031/api/ADPTest"; 

                var response = await client.GetAsync(url);

                Console.WriteLine(response); 

            }
        }
    }
}
