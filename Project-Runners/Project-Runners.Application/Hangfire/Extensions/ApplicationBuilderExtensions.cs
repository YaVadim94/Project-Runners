using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProjectRunners.Application.Hangfire.JobRunners;

namespace ProjectRunners.Application.Hangfire.Extensions
{
    /// <summary>
    /// Расширения для <see cref="IApplicationBuilder"/>
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder StartBackgroundServices(this IApplicationBuilder app)
        {
            var baseType = typeof(JobRunnerBase);
            var assembly = baseType.Assembly;

            var jobRunnerTypes = assembly.GetTypes().Where(type => type.BaseType == baseType);

            foreach (var jobRunnerType in jobRunnerTypes)
            {
                var jobRunner = app.ApplicationServices.GetRequiredService(jobRunnerType) as JobRunnerBase;

                jobRunner?.Start();
            }

            return app;
        }
    }
}