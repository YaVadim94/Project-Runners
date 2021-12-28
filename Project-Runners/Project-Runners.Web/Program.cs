using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ProjectRunners.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).UseSerilog().Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //Возможно, выстрелит в ногу, сделано, чтобы работали grpc
                    webBuilder.ConfigureKestrel(opt =>
                        opt.ListenAnyIP(80, options => options.Protocols = HttpProtocols.Http2));
                    
                    webBuilder.UseStartup<Startup>();
                });
    }
}