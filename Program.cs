using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace andead.alice.yeelight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("config.json", optional: false, reloadOnChange: true);
                })
                .ConfigureKestrel((hostingContext, options) =>
                {
                    int listenPort = hostingContext.Configuration.GetValue<int>("ListenPort", 5055);
                    string certFileName = hostingContext.Configuration.GetValue<string>("CertificateFileName");
                    string certPassword = hostingContext.Configuration.GetValue<string>("CertificatePassword");

                    options.Listen(IPAddress.Any, listenPort, listenOptions => {
                        listenOptions.UseHttps(certFileName, certPassword);
                    });
                })
                .UseStartup<Startup>();
    }
}
