using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = new WebHostBuilder()
            //    .UseKestrel()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseIISIntegration()
            //    .UseStartup<Startup>()
            //    .Build();

            //host.Run();

            var configuration = new ConfigurationBuilder()
                        .AddCommandLine(args)
                        .Build();

            var hostUrl = configuration["hosturl"];
            if (string.IsNullOrEmpty(hostUrl))
                hostUrl = "http://0.0.0.0:5000";


            var host = new WebHostBuilder()
             .UseKestrel()
             .UseUrls(hostUrl)
             .UseContentRoot(Directory.GetCurrentDirectory())
             .UseConfiguration(configuration)
             .UseIISIntegration()
             .UseStartup<Startup>()
             .Build();

            host.Run();

            //dotnet run --server.urls = http://localhost:5001/
        }
    }
}
