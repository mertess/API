using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace Web_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateImgDirectory();
            CreateHostBuilder(args).Build().Run();
        }

        private static void CreateImgDirectory()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Images"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Images");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
    }
}
