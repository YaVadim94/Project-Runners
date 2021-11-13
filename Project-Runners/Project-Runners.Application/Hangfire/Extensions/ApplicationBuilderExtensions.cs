using System;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Project_Runners.Application.Hangfire.Extensions
{
    /// <summary>
    /// Расширения для <see cref="IServiceCollection"/>
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddRunCreator(this IApplicationBuilder app)
        {
            RecurringJob.AddOrUpdate("RunCreator", () => Console.WriteLine("Run Created"), Cron.Minutely);
            return app;
        }
    }
}