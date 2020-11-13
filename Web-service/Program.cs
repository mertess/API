using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog.Fluent;
using NLog.Web;
using System;
using System.IO;

namespace Web_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateImgLogDirectories();
            CreateHostBuilder(args).Build().Run();
        }

        private static void CreateImgLogDirectories()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Images"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Images");
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Logs"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Logs");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
    }
}
