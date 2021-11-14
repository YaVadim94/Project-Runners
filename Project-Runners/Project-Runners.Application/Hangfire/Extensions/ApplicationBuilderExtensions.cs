using System;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Project_Runners.Application.Hangfire.JobRunners;

namespace Project_Runners.Application.Hangfire.Extensions
{
    /// <summary>
    /// Расширения для <see cref="IServiceCollection"/>
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddRunCreator(this IApplicationBuilder app)
        {
            var runner = app.ApplicationServices.GetRequiredService<IRunCreateJobRunner>();
            
            runner.Start();

            return app;
        }
    }
}