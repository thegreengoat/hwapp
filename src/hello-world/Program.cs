
//using System;
//using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:5000/")
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }

    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {            
            app.Run(async (context) =>
            {
                var a = new App(new DefaultRandomizer());
                await context.Response.WriteAsync(a.getWelcomeMessage());
            });
        }
    }
}
