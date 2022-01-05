using System;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace Project_Runners.Frontend.Extensions
{
    /// <summary>
    /// Расширения для <see cref="HttpClient"/>
    /// </summary>
    public static class HttpClientExtensions
    {
        public static void ConfigureAsHttp2(this HttpClient client, IConfiguration configuration)
        {
            client.BaseAddress = new Uri(configuration.GetSection("ProjectRunners.Api").Value);
            client.DefaultRequestVersion = HttpVersion.Version20;
            client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact;
        }
    }
}