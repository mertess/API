using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("url = ");
            string url = Console.ReadLine();
            Console.Write("thread count = ");
            int threadCount = Convert.ToInt32(Console.ReadLine());
            Console.Write("image count = ");
            int imageCount = Convert.ToInt32(Console.ReadLine());

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:56002");

            var response = httpClient.GetAsync($"api/main/getimages?url={url}&threadcount={threadCount}&imagecount={imageCount}").Result;
            var responseHeader = response.Headers.FirstOrDefault(h => h.Key.Equals("Operation-result"));
            Console.Write(responseHeader.Key + " ");
            foreach (var str in responseHeader.Value)
                Console.Write(str);
            Console.WriteLine();
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            httpClient.Dispose();
            Console.ReadLine();
        }
    }
}
