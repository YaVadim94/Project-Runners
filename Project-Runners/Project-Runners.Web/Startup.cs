using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using AutoMapper.EquivalencyExpression;
using Hangfire;
using Hangfire.MemoryStorage;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectRunners.Application.Hangfire.Extensions;
using ProjectRunners.Application.Hangfire.JobRunners;
using ProjectRunners.Application.RabbitMQ;
using ProjectRunners.Application.Runs.Mapping;
using ProjectRunners.Data;
using ProjectRunners.Web.Helpers;
using Serilog;

namespace ProjectRunners.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration, "Serilog")
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("InMem"));
            services.AddAutoMapper(opt => opt.AddCollectionMappers(), GetAssemblies());
            services.AddHangfire(opt =>
            {
                opt.UseSerilogLogProvider();
                opt.UseMemoryStorage();
            });
            
            services.AddHangfireServer();
            services.AddMediatR(GetAssemblies().ToArray());
            
            services
                .AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddTransient<UpdateRunsQueueJobRunner>();
            services.AddTransient<SendRunnersStateJobRunner>();
            services.AddSingleton<IMessageBusService, MessageBusService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseHangfireDashboard();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            DataSeedingHelper.SeedDataBase(app);
            app.StartBackgroundServices();
        }

        private IEnumerable<Assembly> GetAssemblies()
        {
            yield return GetType().Assembly;
            yield return typeof(RunsProfile).Assembly;
            yield return typeof(DataContext).Assembly;
        }
    }
}