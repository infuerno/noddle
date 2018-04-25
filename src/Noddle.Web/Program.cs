using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Noddle.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            IHostingEnvironment hostingEnvironment = null;
            return WebHost.CreateDefaultBuilder(args)
                // get hosting environment
                // and only add kestrel options for development
                // see https://github.com/aspnet/KestrelHttpServer/issues/1334
                .ConfigureAppConfiguration((hostingContext, config) => {
                    hostingEnvironment = hostingContext.HostingEnvironment;
                })
                .UseKestrel(options =>
                {
                    if (hostingEnvironment.IsDevelopment())
                    {
                        options.Listen(IPAddress.Loopback, 5000);
                        options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                        {
                            listenOptions.UseHttps("localhost.pfx", "extra");
                        });
                    }
                })
                .UseStartup<Startup>()
                .Build();
        }
    }
}
