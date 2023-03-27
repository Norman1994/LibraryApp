using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
namespace Library.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>

        Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    //logging.AddFilter("Microsoft.AspNetCore", LogLevel.Error)
                    //.AddFilter("Microsoft.AspNetCore.DataProtection", LogLevel.Error)
                    //.AddFilter("Microsoft.AspNetCore.HostFiltering", LogLevel.Error)
                    //.AddFilter("Microsoft.AspNetCore.Hosting", LogLevel.Error)
                    //.AddFilter("Microsoft.AspNetCore.Mvc", LogLevel.Error)
                    //.AddFilter("Microsoft.AspNetCore.Routing", LogLevel.Error)
                    //.AddFilter("Microsoft.AspNetCore.Server", LogLevel.Error)
                    //.AddFilter("Microsoft.AspNetCore.StaticFiles", LogLevel.Error)
                    //.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Error);
                    //logging.AddFile("logs/AppLog.txt");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        
    }
}
