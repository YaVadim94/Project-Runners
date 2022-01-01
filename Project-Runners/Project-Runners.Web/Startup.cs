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
using ProjectRunners.Application.Runs.Mapping;
using ProjectRunners.Application.Services;
using ProjectRunners.Common.MessageBroker;
using ProjectRunners.Common.MessageBroker.Publishing;
using ProjectRunners.Data;
using ProjectRunners.Web.Controllers.Grpc;
using ProjectRunners.Web.Helpers;
using Serilog;
using StackExchange.Redis;

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
                // opt.UseSerilogLogProvider();
                opt.UseMemoryStorage();
            });
            
            services.AddHangfireServer();
            services.AddMediatR(GetAssemblies().ToArray());
            services.AddGrpc();
            
            services
                .AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddTransient<UpdateRunsQueueJobRunner>();
            services.AddTransient<SendRunnersStateJobRunner>();
            services.AddTransient<IdentifyInactiveJobRunner>();
            services.AddSingleton<IMessagePublishService, MessagePublishService>();
            services.AddSingleton<IConnectionMultiplexer>(x =>
                ConnectionMultiplexer.Connect(Configuration.GetValue<string>("Redis")));
            services.AddSingleton<ICacheService, RedisCacheService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseHangfireDashboard();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<RunnersController>();
            });

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