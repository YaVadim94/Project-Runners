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
using Project_Runners.Application.Hangfire.Extensions;
using Project_Runners.Application.Hangfire.JobRunners;
using Project_Runners.Application.RabbitMQ;
using Project_Runners.Application.Runs.Mapping;
using Project_Runners.Data;
using Project_Runners.Web.Helpers;
using Serilog;

namespace Project_Runners.Web
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

            services.AddTransient<IRunCreateJobRunner, RunCreateJobRunner>();
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
            app.AddRunCreator();

            app.ApplicationServices.GetRequiredService<IMessageBusService>();
        }

        private IEnumerable<Assembly> GetAssemblies()
        {
            yield return GetType().Assembly;
            yield return typeof(RunsProfile).Assembly;
            yield return typeof(DataContext).Assembly;
        }
    }
}